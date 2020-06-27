using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class MetadataProviderTests : MetadataProviderSetup
    {
        [Fact]
        public void CanCreateBindingMetadata()
        {
            var (key, attributes) = GetMockedDependencies();
            var context = new BindingMetadataProviderContext(key, attributes);

            _bindingProvider.CreateBindingMetadata(context);
        }

        [Fact]
        public void CanCreateDisplayMetadata()
        {
            var (key, attributes) = GetMockedDependencies();

            var context = new DisplayMetadataProviderContext(key, attributes);

            _displayProvider.CreateDisplayMetadata(context);
        }

        [Fact]
        public void CanCreateValidationMetadata()
        {
            var (key, attributes) = GetMockedDependencies();
            var context = new ValidationMetadataProviderContext(key, attributes);

            _validationProvider.CreateValidationMetadata(context);
        }
    }
}