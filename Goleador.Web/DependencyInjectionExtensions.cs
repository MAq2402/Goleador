using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Goleador.Application.Messages.Decorators;
using Goleador.Application.Messages.Handlers;
using Goleador.Application.Read.MessageHandlers;
using Goleador.Application.Read.Repositories;
using Goleador.Application.Read.Services;
using Goleador.Infrastructure.BookSearch.Services;
using Goleador.Infrastructure.Events;
using Goleador.Infrastructure.Messages;
using Goleador.Infrastructure.RealTimeServices;
using Goleador.Infrastructure.Repositories;
using Goleador.Infrastructure.SMS;
using Goleador.Web.Dispatchers;
using Microsoft.AspNetCore.SignalR;

namespace Goleador.Web
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterMessageHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BookAddedToFutureReadListHandler)))
                .AsClosedTypesOf(typeof(IMessageHandler<>));
            builder.RegisterGenericDecorator(typeof(PublishBooksToHubDecorator<>), typeof(IMessageHandler<>));
        }

        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfCoreWriteRepository<>)).As(typeof(Domain.Base.IRepository<>));
            builder.RegisterGeneric(typeof(MongoReadRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<BookReadRepository>().As<IBookRepository>();
        }

        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<BookSearchService>().As<IBookSearchService>();
            builder.RegisterType<BookHubService>().As<IBookHubService>();
            builder.RegisterType<UserIdProvider>().As<IUserIdProvider>();
            builder.RegisterType<SmsService>().As<ISmsService>();
        }

        public static void RegisterDispatchers(this ContainerBuilder builder)
        {
            builder.RegisterType<MessageDispatcher>().As<IMessageDispatcher>();
            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>();
        }
    }
}
