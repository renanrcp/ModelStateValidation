using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace ModelStateValidation.Tests
{
    public class CompositeMetadataDetailsProviderSetup : DISetup
    {
        protected readonly ICompositeMetadataDetailsProvider _compositeMetadataDetailsProvider;

        public CompositeMetadataDetailsProviderSetup()
        {
            _compositeMetadataDetailsProvider = _provider.GetRequiredService<ICompositeMetadataDetailsProvider>();
        }

        protected (ModelMetadataIdentity, ModelAttributes) GetMockedDependencies()
        {
            var modelType = typeof(CompositeModel);

            var key = ModelMetadataIdentity.ForType(modelType);
            var attributes = ModelAttributes.GetAttributesForType(modelType);

            return (key, attributes);
        }
    }
}