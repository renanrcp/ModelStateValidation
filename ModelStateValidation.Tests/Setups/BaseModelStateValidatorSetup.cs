using Microsoft.Extensions.DependencyInjection;

namespace ModelStateValidation.Tests
{
    public abstract class BaseModelStateValidatorSetup : BaseDISetup
    {
        protected readonly IModelStateValidator _validator;

        protected BaseModelStateValidatorSetup()
        {
            _validator = _provider.GetRequiredService<IModelStateValidator>();
        }
    }
}