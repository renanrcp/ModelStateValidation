using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace ModelStateValidation
{
    internal sealed class ModelStateValidationPostConfigurer : IConfigureOptions<MvcOptions>
    {
        private readonly IStringLocalizerFactory _stringLocalizerFactory;
        private readonly IValidationAttributeAdapterProvider _validationAttributeAdapterProvider;
        private readonly IOptions<MvcDataAnnotationsLocalizationOptions> _dataAnnotationLocalizationOptions;

        public ModelStateValidationPostConfigurer(
            IValidationAttributeAdapterProvider validationAttributeAdapterProvider,
            IOptions<MvcDataAnnotationsLocalizationOptions> dataAnnotationLocalizationOptions,
            IStringLocalizerFactory stringLocalizerFactory)
        {
            if (validationAttributeAdapterProvider == null)
            {
                throw new ArgumentNullException(nameof(validationAttributeAdapterProvider));
            }

            if (dataAnnotationLocalizationOptions == null)
            {
                throw new ArgumentNullException(nameof(dataAnnotationLocalizationOptions));
            }

            _validationAttributeAdapterProvider = validationAttributeAdapterProvider;
            _dataAnnotationLocalizationOptions = dataAnnotationLocalizationOptions;
            _stringLocalizerFactory = stringLocalizerFactory;
        }
        public void Configure(MvcOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.ModelMetadataDetailsProviders.Add(new DataAnnotationsMetadataProvider(
                options,
                _dataAnnotationLocalizationOptions,
                _stringLocalizerFactory));

            options.ModelValidatorProviders.Add(new DefaultModelValidatorProvider(
                _validationAttributeAdapterProvider,
                _dataAnnotationLocalizationOptions,
                _stringLocalizerFactory));
        }
    }
}