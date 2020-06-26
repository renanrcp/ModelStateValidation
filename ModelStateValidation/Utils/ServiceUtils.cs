using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            if (Instance == null)
                Instance = CreateDefaultServiceProvider();

            return Instance;
        }

        private static IServiceProvider CreateDefaultServiceProvider()
        {
            return new ServiceCollection()
                                    .TryAddDefaultServices()
                                    .BuildServiceProvider();
        }

        internal static IServiceCollection TryAddDefaultServices(this IServiceCollection services)
        {
            services.AddOptions();

            services.TryAddTransient<IConfigureOptions<MvcOptions>, ModelStateValidationPostConfigurer>();
            services.TryAddSingleton<ILoggerFactory, LoggerFactory>();
            services.TryAddSingleton<IValidationAttributeAdapterProvider, ValidationAttributeAdapterProvider>();
            services.TryAddSingleton<IModelMetadataProvider, DefaultModelMetadataProvider>();
            services.TryAddSingleton<IObjectModelValidator>(s =>
            {
                var options = s.GetRequiredService<IOptions<MvcOptions>>().Value;
                var metadataProvider = s.GetRequiredService<IModelMetadataProvider>();
                return new DefaultObjectValidator(metadataProvider, options.ModelValidatorProviders, options);
            });
            services.TryAddSingleton<ICompositeMetadataDetailsProvider>(s =>
            {
                var options = s.GetRequiredService<IOptions<MvcOptions>>().Value;
                return new DefaultMetadataDetailsProvider(options.ModelMetadataDetailsProviders);
            });

            return services;
        }
    }
}