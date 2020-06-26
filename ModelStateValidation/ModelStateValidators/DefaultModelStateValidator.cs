using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ModelStateValidation
{
    internal class DefaultModelStateValidator : IModelStateValidator
    {
        private readonly IObjectModelValidator _validator;
        private readonly IServiceProvider _provider;

        public DefaultModelStateValidator(IObjectModelValidator validator)
            : this(validator, null)
        {
        }

        public DefaultModelStateValidator(IObjectModelValidator validator, IServiceProvider provider)
        {
            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            _validator = validator;
            _provider = provider ?? ServiceUtils.GetDefaultServiceProvider();
        }

        public bool TryValidateModel(object model, ModelStateDictionary modelState, string prefix)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            var actionContext = ValidatorUtils.CreateActionContext(modelState, _provider);

            _validator.Validate(actionContext, null, prefix, model);

            return modelState.IsValid;
        }
    }
}