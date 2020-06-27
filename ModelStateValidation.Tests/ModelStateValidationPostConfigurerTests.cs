using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class ModelStateValidationPostConfigurerTests : ModelStateValidationPostConfigurerSetup
    {
        [Fact]
        public void TestSetupConfiguration()
        {
            _postConfigurer.Configure(_mvcOptions);

            Assert.NotEmpty(_mvcOptions.ModelMetadataDetailsProviders);
            Assert.NotEmpty(_mvcOptions.ModelValidatorProviders);
        }

        [Fact]
        public void ThrownExceptionWithoutMvcOptions()
        {
            Assert.Throws<ArgumentNullException>(() => _postConfigurer.Configure(null));
        }
    }
}