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
    }
}