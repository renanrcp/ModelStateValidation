using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;

namespace ModelStateValidation
{
    internal sealed class DefaultModelStateValidator : IModelStateValidator
    {
        private readonly IObjectModelValidator _validator;
        private readonly MvcOptions _options;
        private readonly IServiceProvider _provider;

        public DefaultModelStateValidator(IObjectModelValidator validator, IOptions<MvcOptions> options)
            : this(validator, options.Value, null)
        {
        }

        public DefaultModelStateValidator(IObjectModelValidator validator, IOptions<MvcOptions> options, IServiceProvider provider)
            : this(validator, options.Value, provider)
        {
        }

        public DefaultModelStateValidator(IObjectModelValidator validator, ModelStateValidateOptions options)
            : this(validator, ApplyOptions(options), null)
        {
        }

        public DefaultModelStateValidator(IObjectModelValidator validator, ModelStateValidateOptions options, IServiceProvider provider)
            : this(validator, ApplyOptions(options), provider)
        {
        }


        public DefaultModelStateValidator(IObjectModelValidator validator, MvcOptions options, IServiceProvider provider)
        {
            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }
            if (options == null)
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

            actionContext.ModelState.MaxAllowedErrors = _options.MaxModelValidationErrors;

            _validator.Validate(actionContext, null, prefix, model);

            return actionContext.ModelState.IsValid;
        }

        private static MvcOptions ApplyOptions(ModelStateValidateOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var mvcOptions = new MvcOptions();

            options.ConfigureMvc(mvcOptions);

            return mvcOptions;
        }
    }
}