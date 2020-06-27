using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace ModelStateValidation.Tests
{
    public class ObjectModelValidatorSetup : DISetup
    {
        protected readonly IObjectModelValidator _validator;

        public ObjectModelValidatorSetup()
        {
            _validator = _provider.GetRequiredService<IObjectModelValidator>();
        }
    }
}