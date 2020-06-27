using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ModelStateValidation.Tests
{
    public abstract class BaseModelStateValidatorSetup : BaseDISetup
    {
        protected readonly IModelStateValidator _validator;

        protected BaseModelStateValidatorSetup()
        {
            _validator = _provider.GetRequiredService<IModelStateValidator>();
        }

        protected void Pass(object model)
        {
            var modelState = new ModelStateDictionary();

            var result = _validator.TryValidateModel(model, modelState);

            Assert.True(result);
            Assert.Empty(modelState);
        }

        protected void NotPass(object model)
        {
            var modelState = new ModelStateDictionary();

            var result = _validator.TryValidateModel(model, modelState);

            Assert.False(result);
            Assert.NotEmpty(modelState);
        }
    }
}