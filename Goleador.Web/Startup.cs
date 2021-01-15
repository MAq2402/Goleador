using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Infrastructure.DbContext;
using Goleador.Infrastructure.RealTimeServices;
using Goleador.Infrastructure.SMS;
using Goleador.Infrastructure.Types;
using Goleador.Web.Auth;
using Goleador.Web.Dispatchers;
using Hangfire;
using Hangfire.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Goleador.Web
{
    public class Startup
    {
        private readonly string _goleadorCorsPolicyName = "GoleadorCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: _goleadorCorsPolicyName, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddDbContext<GoleadorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.ConfigureAuthentication(Configuration,
               new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Security")["Key"])));

            services.AddMediatR(Assembly.GetAssembly(typeof(AddBookToFutureReadList)),
                Assembly.GetAssembly(typeof(GetBooksQuery)));

            services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage("Server=(localdb)\\mssqllocaldb;Database=Goleador.HangFire;Integrated Security=True;", new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var mongoConfiguration = Configuration.GetSection("GoleadorReadDatabaseSettings");
            var googleBooksApiConfiguration = Configuration.GetSection("GoogleBooksApi");
            var smsConfiguration = Configuration.GetSection("Sms");
            var appSettings = new Settings(new MongoSettings(mongoConfiguration["ConnectionString"],
                    mongoConfiguration["DatabaseName"]),
                new GoogleBooksApiSettings(googleBooksApiConfiguration["Key"]),
                new SmsSettings(smsConfiguration["Key"], smsConfiguration["Secret"], smsConfiguration["From"]));

            builder.Register(context => appSettings).SingleInstance();
            builder.RegisterRepositories();
            builder.RegisterServices();
            builder.RegisterDispatchers();
            builder.RegisterRabbitMq(Configuration.GetSection("RabbitMq"));
            builder.RegisterMessageHandlers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, 
            GoleadorDbContext dbContext,
            ISmsService smsService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.Migrate();

            app.ConfigureExceptionHandler();

            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate(() => smsService.SendMessageAboutBooksInReadAsync("xD", "48505817439", "xDDDDD"), Cron.Daily);
            // backgroundJobs.Requeue(() => Console.WriteLine("Hello world from Hangfire!"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_goleadorCorsPolicyName);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<BookHub>("hub/books");
                endpoints.MapHangfireDashboard();
            });

            app.SubscribeToMessages();
        }
    }
}