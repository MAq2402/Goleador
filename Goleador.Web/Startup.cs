using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Infrastructure.DbContext;
using Goleador.Infrastructure.Messages;
using Goleador.Infrastructure.Types;
using Goleador.Web.Dispatchers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Goleador.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<GoleadorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(Assembly.GetAssembly(typeof(AddBookToFutureReadList)),
                Assembly.GetAssembly(typeof(GetBooksQuery)));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var mongoConfiguration = Configuration.GetSection("GoleadorReadDatabaseSettings");
            var googleBooksApiConfiguration = Configuration.GetSection("GoogleBooksApi");
            var appSettings = new Settings(new MongoSettings(mongoConfiguration["ConnectionString"],
                    mongoConfiguration["DatabaseName"]),
                new GoogleBooksApiSettings(googleBooksApiConfiguration["Key"]));

            builder.Register(context => appSettings).SingleInstance();
            builder.RegisterRepositories();
            builder.RegisterServices();
            builder.RegisterType<MessageDispatcher>().As<IMessageDispatcher>();
            builder.RegisterRabbitMq(Configuration.GetSection("RabbitMq"));
            builder.RegisterMessageHandlers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GoleadorDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.SubscribeToMessages();
        }
    }
}