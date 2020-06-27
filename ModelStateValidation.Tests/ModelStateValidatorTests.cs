using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class ModelStateValidatorTests : BaseModelStateValidatorSetup
    {
        [Fact]
        public void NotPassWithNullString()
        {
            var model = new RequiredModel();
            var modelState = new ModelStateDictionary();

            var result = _validator.TryValidateModel(model, modelState);

            Assert.False(result);
            Assert.NotEmpty(modelState);
        }
    }
}