using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ModelStateValidation
{
    /// <summary>
    /// General extensions for Model State.
    /// </summary>
    public static class ModelStateValidationExtensions
    {
        /// <summary>
        /// Add the <see cref="IModelStateValidator" /> to the dependencies.
        /// </summary>
        /// <param name="services">The current service collection to be builded.</param>
        /// <returns>The current service collection to be builded.</returns>
        public static IServiceCollection AddModelStateValidation(this IServiceCollection services)
            => services.TryAddDefaultServices();

        /// <summary>
        /// Add the <see cref="IModelStateValidator" /> to the dependencies and configure some options.
        /// </summary>
        /// <param name="services">The current service collection to be builded.</param>
        /// <param name="configure">The ModelStateValidateOptions to be configured.</param>
        /// <returns>The current service collection to be builded.</returns>
        public static IServiceCollection AddModelStateValidation(this IServiceCollection services, Action<ModelStateValidateOptions> configure)
        {
            if (configure != null)
            {
                var options = new ModelStateValidateOptions();

                configure(options);

                services.Configure<MvcOptions>(options.ConfigureMvc);
            }

            return services.AddModelStateValidation();
        }
    }
}