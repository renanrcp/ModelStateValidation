using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class DependencyInjectionTests : DISetup
    {
        [Fact]
        public void CanGetModelStateValidator()
        {
            var validator = _provider.GetService<IModelStateValidator>();

            Assert.NotNull(validator);
        }

        [Fact]
        public void CanGetOptions()
        {
            var options = _provider.GetService<IOptions<MvcOptions>>();

            Assert.NotNull(options);
        }

        [Fact]
        public void CanGetValidateAttributeAdapter()
        {
            var adapter = _provider.GetService<IValidationAttributeAdapterProvider>();

            Assert.NotNull(adapter);
        }

        [Fact]
        public void CanGetModelMetadataProvider()
        {
            var metadataProvider = _provider.GetService<IModelMetadataProvider>();

            Assert.NotNull(metadataProvider);
        }

        [Fact]
        public void CanGetLoggerFactory()
        {
            var loggerFactory = _provider.GetService<ILoggerFactory>();

            Assert.NotNull(loggerFactory);
        }

        [Fact]
        public void CanGetCompositeMetadataDetailsProvider()
        {
            var compositeMetadataDetailsProvider = _provider.GetService<ICompositeMetadataDetailsProvider>();

            Assert.NotNull(compositeMetadataDetailsProvider);
        }

        [Fact]
        public void CanGetObjectModelValidator()
        {
            var validator = _provider.GetService<IObjectModelValidator>();

            Assert.NotNull(validator);
        }
    }
}
