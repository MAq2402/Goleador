using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Goleador.Application.Messages.Decorators;
using Goleador.Application.Messages.Handlers;
using Goleador.Application.Messages.Messages;
using Goleador.Application.Read.Repositories;
using Goleador.Domain.Base;
using Goleador.Infrastructure.BookSearch.Services;
using Goleador.Infrastructure.Messages;
using Goleador.Infrastructure.RealTimeServices;
using Goleador.Infrastructure.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Goleador.Web
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterMessageHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BookAddedToFutureReadList)))
                .AsClosedTypesOf(typeof(IMessageHandler<>));
            builder.RegisterGenericDecorator(typeof(PublishBooksToHubDecorator<>), typeof(IMessageHandler<>));
        }

        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(WriteRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(ReadRepository<>)).As(typeof(IReadRepository<>));
            builder.RegisterType<BookRepository>().As<IBookRepository>();
        }

        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<BookSearchService>().As<IBookSearchService>();
            builder.RegisterType<BookHubService>().As<IBookHubService>();
            builder.RegisterType<UserIdProvider>().As<IUserIdProvider>();
        }
    }
}
