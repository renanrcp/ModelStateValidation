using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ModelStateValidation.Tests
{
    public class DataAnnotationsModelValidatorProviderSetup : CompositeMetadataDetailsProviderSetup
    {
        internal readonly DataAnnotationsModelValidatorProvider _modelValidatorProvider;

        protected DataAnnotationsModelValidatorProviderSetup()
        {
            var validationAttributeAdapter = _provider.GetRequiredService<IValidationAttributeAdapterProvider>();
            var options = _provider.GetRequiredService<IOptions<MvcDataAnnotationsLocalizationOptions>>();

            _modelValidatorProvider = new DataAnnotationsModelValidatorProvider(validationAttributeAdapter, options, null);
        }

        protected ModelValidatorProviderContext GetMockedContext()
        {
            var options = _provider.GetRequiredService<IOptions<MvcOptions>>();
            var provider = new DefaultModelMetadataProvider(_compositeMetadataDetailsProvider, options);
            var metadata = provider.GetMetadataForType(typeof(ValidatableObject));

            var context = new ModelValidatorProviderContext(metadata, GetValidatorItems(metadata));

            return context;
        }

        protected IList<ValidatorItem> GetValidatorItems(ModelMetadata metadata)
        {
            return metadata.ValidatorMetadata
                            .Select(a => new ValidatorItem(a))
                            .ToList();
        }
    }
}