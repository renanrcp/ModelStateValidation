using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelStateValidation
{
    /// <summary>
    /// A dependency that can validate any object model.
    /// </summary>
    public interface IModelStateValidator
    {
        /// <summary>
        /// Try validate a model with the specified model state and model prefix.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="modelState">The current <see cref="ModelStateDictionary" /> where erros will be added.</param>
        /// <param name="prefix">The model prefix.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        bool TryValidateModel(object model, ModelStateDictionary modelState, string prefix);

        /// <summary>
        /// Try validate a model with the specified model state.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="modelState">The current <see cref="ModelStateDictionary" /> where erros will be added.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        bool TryValidateModel(object model, ModelStateDictionary modelState)
            => TryValidateModel(model, modelState, string.Empty);

        /// <summary>
        /// Try validate a model with the specified model prefix.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="prefix">The model prefix.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        bool TryValidateModel(object model, string prefix)
            => TryValidateModel(model, new ModelStateDictionary(), prefix);

        /// <summary>
        /// Try validate a model.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <returns><see langword="true" /> if the model is valid.</returns>
        bool TryValidateModel(object model)
            => TryValidateModel(model, new ModelStateDictionary());
    }
}