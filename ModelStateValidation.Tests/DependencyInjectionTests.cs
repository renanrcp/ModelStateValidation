using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class DependencyInjectionTests : BaseDISetup
    {
        [Fact]
        public void CanGetModelStateValidator()
        {
            var validator = _provider.GetService<IModelStateValidator>();

            Assert.NotNull(validator);
        }
    }
}
