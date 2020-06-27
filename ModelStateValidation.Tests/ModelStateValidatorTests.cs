using Xunit;

namespace ModelStateValidation.Tests
{
    public class ModelStateValidatorTests : BaseModelStateValidatorSetup
    {
        [Fact]
        public void NotPassWithNullString()
        {
            var model = new RequiredModel();

            var result = _validator.TryValidateModel(model);
        }
    }
}