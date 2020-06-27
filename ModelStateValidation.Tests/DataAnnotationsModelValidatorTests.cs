using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class DataAnnotationsModelValidatorTests : DataAnnotationsModelValidatorSetup
    {
        [Fact]
        public void RequiredButNullAtTopLevelInvalid()
        {
            var context = GetMockedValidationContext();

            var result = _validator.Validate(context);

            var validationResult = result.Single();
            Assert.Empty(validationResult.MemberName);
            Assert.Equal(new RequiredAttribute().FormatErrorMessage("Length"), validationResult.Message);
        }

        [Fact]
        public void RequiredAndNotNullAtTopLevelValid()
        {
            var context = GetMockedValidationContext(123);

            var result = _validator.Validate(context);

            Assert.Empty(result);
        }

        [Fact]
        public void PassWithRequired()
        {
            var container = new RequiredModel()
            {
                Summary = "Hello",
            };
            var model = container.Summary;

            var context = GetMockedValidationContextForModel(model, container);

            var result = _validator.Validate(context);

            Assert.Empty(result);
        }

        [Fact]
        public void NotPassWithRequired()
        {
            var container = new RequiredModel()
            {
                Summary = string.Empty,
            };
            var model = container.Summary;

            var context = GetMockedValidationContextForModel(model, container);

            var result = _validator.Validate(context);

            Assert.NotEmpty(result);

            var validationResult = result.Single();

            // This is a validation at type level, and the membername will be setted to empty.
            Assert.Empty(validationResult.MemberName);
            Assert.Equal(new RequiredAttribute().FormatErrorMessage("Summary"), validationResult.Message);
        }
    }
}