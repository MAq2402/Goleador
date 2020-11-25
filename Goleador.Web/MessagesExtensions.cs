using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Goleador.Domain.Base;
using Goleador.Web.Dispatchers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Goleador.Web
{
    public static class MessagesExtensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfigurationSection section)
        {
            var options = new RawRabbitConfiguration();
            section.Bind(options);

            var client = BusClientFactory.CreateDefault(options);
            services.AddSingleton<IBusClient>(_ => client);
        }

        public static void RegisterRabbitMq(this ContainerBuilder builder, IConfigurationSection section)
        {
            var options = new RawRabbitConfiguration();

            section.Bind(options);

            var client = BusClientFactory.CreateDefault(options);

            builder.Register<IBusClient>(context => client).SingleInstance();
        }

        public static IApplicationBuilder SubscribeToMessages(this IApplicationBuilder app)
        {
            var messageDispatcher = app.ApplicationServices.GetAutofacRoot().Resolve<IMessageDispatcher>();

            var busClient = app.ApplicationServices.GetService<IBusClient>();

            busClient
                .SubscribeAsync<IEvent>(async (message, context) =>
                {
                    await messageDispatcher.DispatchAsync(message);
                });

            return app;
        }
    }
}
