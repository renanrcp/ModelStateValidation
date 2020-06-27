using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ModelStateValidation.Tests
{
    public class MetadataProviderSetup : DISetup
    {
        protected readonly IBindingMetadataProvider _bindingProvider;
        protected readonly IDisplayMetadataProvider _displayProvider;
        protected readonly IValidationMetadataProvider _validationProvider;

        public MetadataProviderSetup()
        {
            var options = _provider.GetRequiredService<IOptions<MvcOptions>>();
            var providers = options.Value.ModelMetadataDetailsProviders;

            _bindingProvider = providers.OfType<IBindingMetadataProvider>().FirstOrDefault();
            _displayProvider = providers.OfType<IDisplayMetadataProvider>().FirstOrDefault();
            _validationProvider = providers.OfType<IValidationMetadataProvider>().FirstOrDefault();
        }

        protected (ModelMetadataIdentity key, ModelAttributes attributes) GetMockedDependencies()
        {
            var modelType = typeof(CompositeModel);

            var key = ModelMetadataIdentity.ForType(modelType);
            var attributes = ModelAttributes.GetAttributesForType(modelType);

            return (key, attributes);
        }
    }
}