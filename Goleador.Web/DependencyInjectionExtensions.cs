using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Goleador.Application.Messages.Messages;
using Goleador.Domain.Base;
using Goleador.Infrastructure.Repositories;
using Goleador.Infrastructure.Types;

namespace Goleador.Web
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterMessageHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BookAddedToFutureReadList)))
                .AsClosedTypesOf(typeof(IMessageHandler<>));
        }

        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(WriteRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(ReadRepository<>)).As(typeof(IReadRepository<>));
        }
    }
}
