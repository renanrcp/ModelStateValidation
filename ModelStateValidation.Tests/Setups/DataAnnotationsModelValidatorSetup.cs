using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ModelStateValidation.Tests
{
    public class DataAnnotationsModelValidatorSetup : CompositeMetadataDetailsProviderSetup
    {
        internal readonly DataAnnotationsModelValidator _validator;

        public DataAnnotationsModelValidatorSetup()
        {
            _validator = new DataAnnotationsModelValidator(
                new ValidationAttributeAdapterProvider(),
                new RequiredAttribute(),
                null);
        }

        protected ModelValidationContext GetMockedValidationContext(object model = null, object container = null)
        {
            var actionContext = ValidatorUtils.CreateActionContext();
            var options = _provider.GetRequiredService<IOptions<MvcOptions>>();
            var provider = new DefaultModelMetadataProvider(_compositeMetadataDetailsProvider, options);
            var metadata = provider.GetMetadataForProperty(typeof(string).GetProperty("Length"), typeof(string));

            var context = new ModelValidationContext(actionContext, metadata, provider, container, model);

            return context;
        }

        protected ModelValidationContext GetMockedValidationContextForModel(object model, object container = null)
        {
            var actionContext = ValidatorUtils.CreateActionContext();
            var options = _provider.GetRequiredService<IOptions<MvcOptions>>();
            var provider = new DefaultModelMetadataProvider(_compositeMetadataDetailsProvider, options);
            var metadata = provider.GetMetadataForProperty(typeof(RequiredModel).GetProperty("Summary"), typeof(RequiredModel));

            var context = new ModelValidationContext(actionContext, metadata, provider, container, model);

            return context;
        }
    }
}