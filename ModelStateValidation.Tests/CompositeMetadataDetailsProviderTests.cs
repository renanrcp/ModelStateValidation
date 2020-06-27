using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Moq;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class CompositeMetadataDetailsProviderTests : CompositeMetadataDetailsProviderSetup
    {
        [Fact]
        public void CanCreateBindingMetadata()
        {
            var (key, attributes) = GetMockedDependencies();
            var context = new BindingMetadataProviderContext(key, attributes);

            _compositeMetadataDetailsProvider.CreateBindingMetadata(context);
        }

        [Fact]
        public void CanCreateDisplayMetadata()
        {
            var (key, attributes) = GetMockedDependencies();

            var context = new DisplayMetadataProviderContext(key, attributes);

            _compositeMetadataDetailsProvider.CreateDisplayMetadata(context);
        }

        [Fact]
        public void CanCreateValidationMetadata()
        {
            var (key, attributes) = GetMockedDependencies();
            var context = new ValidationMetadataProviderContext(key, attributes);

            _compositeMetadataDetailsProvider.CreateValidationMetadata(context);
        }
    }
}