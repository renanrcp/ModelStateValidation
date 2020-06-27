using System;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class ObjectModelValidatorTests : ObjectModelValidatorSetup
    {
        [Fact]
        public void NotPassRequired()
        {
            var model = new RequiredModel
            {
                Summary = string.Empty,
            };

            var actionContext = ValidatorUtils.CreateActionContext();

            _validator.Validate(actionContext, null, string.Empty, model);

            Assert.False(actionContext.ModelState.IsValid);
            Assert.NotEmpty(actionContext.ModelState);
        }

        [Fact]
        public void PassRequired()
        {
            var model = new RequiredModel
            {
                Summary = Guid.NewGuid().ToString(),
            };

            var actionContext = ValidatorUtils.CreateActionContext();

            _validator.Validate(actionContext, null, string.Empty, model);

            Assert.True(actionContext.ModelState.IsValid);
            Assert.Empty(actionContext.ModelState);
        }
    }
}