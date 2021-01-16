using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Goleador.Web
{
    public static class SchedulerExtensions
    {
        public static void AddScheduler(this IServiceCollection services, string databaseConnection)
        {
            services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(databaseConnection, new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    }));

            services.AddHangfireServer();
        }

        public static void UseScheduler(this IApplicationBuilder appBuilder, Expression<Action> methodCall, string cronExpression)
        {
            appBuilder.UseHangfireDashboard();
            RecurringJob.AddOrUpdate(methodCall, cronExpression);
        }
    }
}
