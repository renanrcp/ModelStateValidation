using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ModelStateValidation
{
    /// <summary>
    /// Some options for the <see cref="IModelStateValidator" />.
    /// </summary>
    public class ModelStateValidateOptions
    {
        /// <summary>
        /// Gets a list of <see cref="IModelValidatorProvider" /> used by this application.
        /// </summary>
        public IList<IModelValidatorProvider> ModelValidatorProviders { get; } = new List<IModelValidatorProvider>();

        /// <summary>
        /// Gets a list of <see cref="IMetadataDetailsProvider"/> instances that will be used to
        /// create <see cref="ModelMetadata"/> instances.
        /// </summary>
        /// <remarks>
        /// A provider should implement one or more of the following interfaces, depending on what
        /// kind of details are provided:
        /// <ul>
        /// <li><see cref="IBindingMetadataProvider"/></li>
        /// <li><see cref="IDisplayMetadataProvider"/></li>
        /// <li><see cref="IValidationMetadataProvider"/></li>
        /// </ul>
        /// </remarks>
        public IList<IMetadataDetailsProvider> ModelMetadataDetailsProviders { get; } = new List<IMetadataDetailsProvider>();

        /// <summary>
        /// Gets or sets the maximum number of validation errors that are allowed by this 
        /// application before further errors are ignored.
        /// </summary>
        /// <value>
        /// The default value is 200.
        /// </value>
        public int MaxModelValidationErrors { get; set; } = 200;

        /// <summary>
        /// Gets or sets the maximum depth to constrain the validation visitor when validating.
        ///  Set to null to disable this feature. 
        /// <see cref="ValidationVisitor" /> traverses the object graph of the model being validated. 
        /// For models that are very deep or are infinitely recursive, validation may result in stack 
        /// overflow.
        /// When not null, <see cref="ValidationVisitor" /> will throw if traversing an object 
        /// exceeds the maximum allowed validation depth.
        /// This property is associated with a compatibility switch and can provide a different
        /// behavior depending on the configured compatibility version for the application.
        /// See <see cref="CompatibilityVersion" /> for guidance and examples of setting the 
        /// application's compatibility version.
        /// Configuring the desired value of the compatibility switch by calling this property's
        /// setter will take precedence over the value implied by the application's 
        /// <see cref="CompatibilityVersion" />.
        /// If the application's compatibility version is set to <see cref="CompatibilityVersion.Version_2_2" />
        /// then this setting will have the value 200 unless explicitly configured.
        /// If the application's compatibility version is set to <see cref="CompatibilityVersion.Version_2_1" />
        /// or earlier then this setting will have the value null unless explicitly configured.
        /// </summary>
        /// <value>
        /// The default value is 32.
        /// </value>
        public int? MaxValidationDepth { get; set; } = 32;

        /// <summary>
        /// Gets or sets a value that determines whether the validation visitor will perform 
        /// validation of a complex type if validation fails for any of its children.
        /// <seealso cref="ValidationVisitor.ValidateComplexTypesIfChildValidationFails"/>
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        public bool ValidateComplexTypesIfChildValidationFails { get; set; }

        /// <summary>
        /// Gets or sets a value that detemines if the inference of <see cref="RequiredAttribute"/> for
        /// for properties and parameters of non-nullable reference types is suppressed. If <c>false</c>
        /// (the default), then all non-nullable reference types will behave as-if <c>[Required]</c> has
        /// been applied. If <c>true</c>, this behavior will be suppressed; nullable reference types and
        /// non-nullable reference types will behave the same for the purposes of validation.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This option controls whether MVC model binding and validation treats nullable and non-nullable
        /// reference types differently.
        /// </para>
        /// <para>
        /// By default, MVC will treat a non-nullable reference type parameters and properties as-if
        /// <c>[Required]</c> has been applied, resulting in validation errors when no value was bound.
        /// </para>
        /// <para>
        /// MVC does not support non-nullable reference type annotations on type arguments and type parameter
        /// contraints. The framework will not infer any validation attributes for generic-typed properties
        /// or collection elements.
        /// </para>
        /// </remarks>
        public bool SuppressImplicitRequiredAttributeForNonNullableReferenceTypes { get; set; }

        internal void ConfigureMvc(MvcOptions options)
        {
            foreach (var modelValidatorProvider in ModelValidatorProviders)
            {
                options.ModelValidatorProviders.Add(modelValidatorProvider);
            }

            foreach (var modelMetadataDetailsProvider in ModelMetadataDetailsProviders)
            {
                options.ModelMetadataDetailsProviders.Add(modelMetadataDetailsProvider);
            }

            options.MaxModelValidationErrors = MaxModelValidationErrors;
            options.MaxValidationDepth = MaxValidationDepth;
            options.ValidateComplexTypesIfChildValidationFails = ValidateComplexTypesIfChildValidationFails;
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = SuppressImplicitRequiredAttributeForNonNullableReferenceTypes;
        }
    }
}