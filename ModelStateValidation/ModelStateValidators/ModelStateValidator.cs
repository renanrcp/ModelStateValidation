using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace ModelStateValidation
{
    /// <summary>
    /// External and static model state validator, use this if you can't dependency injection.
    /// </summary>
    public static class ModelStateValidator
    {
        /// <summary>
        /// Try validate a model with the specified model state.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="modelState">The current <see cref="ModelStateDictionary" /> where erros will be added.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        public static bool TryValidateModel(object model, ModelStateDictionary modelState)
            => TryValidateModel(model, modelState, string.Empty);

        /// <summary>
        /// Try validate a model.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        public static bool TryValidateModel(object model)
            => TryValidateModel(model, new ModelStateDictionary());

        /// <summary>
        /// Try validate a model with the specified model prefix.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="prefix">The model prefix.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        public static bool TryValidateModel(object model, string prefix)
            => TryValidateModel(model, new ModelStateDictionary(), prefix);

        /// <summary>
        /// Try validate a model with the specified model state and model prefix.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="modelState">The current <see cref="ModelStateDictionary" /> where erros will be added.</param>
        /// <param name="prefix">The model prefix.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        public static bool TryValidateModel(object model, ModelStateDictionary modelState, string prefix)
        {
            var provider = ServiceUtils.GetDefaultServiceProvider();

            var modelStateValidator = provider.GetService<IModelStateValidator>();

            return modelStateValidator.TryValidateModel(model, modelState, prefix);
        }

    }
}