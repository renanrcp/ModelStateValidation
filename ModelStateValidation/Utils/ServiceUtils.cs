using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace ModelStateValidation
{
    internal static class ServiceUtils
    {
        private static IServiceProvider Instance { get; set; }

        static ServiceUtils()
        {
        }

        internal static IServiceProvider GetDefaultServiceProvider()
        {
            if (Instance.HasNoContent())
                Instance = CreateDefaultServiceProvider();

            return Instance;
        }

        private static IServiceProvider CreateDefaultServiceProvider()
        {
            return new ServiceCollection()
                                    .TryAddDefaultServices()
                                    .BuildServiceProvider();
        }

        internal static IServiceCollection TryAddDefaultServices(this IServiceCollection collection)
        {
            collection.TryAddSingleton<ILoggerFactory, LoggerFactory>();

            return collection;
        }
    }
}