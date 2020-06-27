using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ModelStateValidation.Tests
{
    public class ValidatableObjectAdapterSetup : CompositeMetadataDetailsProviderSetup
    {
        internal readonly ValidatableObjectAdapter _adapter;

        public ValidatableObjectAdapterSetup()
        {
            _adapter = new ValidatableObjectAdapter();
        }

        protected ModelValidationContext GetMockedValidationContextWithContainer(ValidatableSampleModel model)
        {
            var container = new ValidatableSampleModelContainer();
            var options = _provider.GetRequiredService<IOptions<MvcOptions>>();
            var actionContext = ValidatorUtils.CreateActionContext();
            var provider = new DefaultModelMetadataProvider(_compositeMetadataDetailsProvider, options);
            var metadata = provider.GetMetadataForType(model.GetType());

            var context = new ModelValidationContext(actionContext, metadata, provider, container, model);

            return context;
        }

        protected ModelValidationContext GetModelValidationContextWithoutContainer(ValidatableSampleModel model)
        {
            var options = _provider.GetRequiredService<IOptions<MvcOptions>>();
            var actionContext = ValidatorUtils.CreateActionContext();
            var provider = new DefaultModelMetadataProvider(_compositeMetadataDetailsProvider, options);
            var metadata = provider.GetMetadataForProperty(
                typeof(ValidatableSampleModelContainer),
                nameof(ValidatableSampleModelContainer.SampleModel));

            var context = new ModelValidationContext(actionContext, metadata, provider, null, model);

            return context;
        }
    }
}