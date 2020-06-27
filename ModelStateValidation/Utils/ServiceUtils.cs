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
                                    .BuildServiceProvider(true);
        }

        internal static IServiceCollection TryAddDefaultServices(this IServiceCollection services)
        {
            services.AddOptions<MvcOptions>();
            services.TryAddSingleton<IValidationAttributeAdapterProvider, ValidationAttributeAdapterProvider>();
            services.TryAddTransient<IConfigureOptions<MvcOptions>, ModelStateValidationPostConfigurer>();
            services.TryAddSingleton<IModelMetadataProvider, DefaultModelMetadataProvider>();
            services.TryAddSingleton<IModelStateValidator, DefaultModelStateValidator>();
            services.TryAddSingleton<ILoggerFactory, LoggerFactory>();
            services.TryAddSingleton<ICompositeMetadataDetailsProvider>(a =>
            {
                var options = a.GetRequiredService<IOptions<MvcOptions>>().Value;
                return new DefaultMetadataDetailsProvider(options.ModelMetadataDetailsProviders);
            });
            services.TryAddSingleton<IObjectModelValidator>(a =>
            {
                var options = a.GetRequiredService<IOptions<MvcOptions>>().Value;
                var metadataProvider = a.GetRequiredService<IModelMetadataProvider>();
                return new DefaultObjectValidator(metadataProvider, options.ModelValidatorProviders, options);
            });

            return services;
        }
    }
}