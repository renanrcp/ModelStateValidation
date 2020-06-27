using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class ValidatableObject : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return null;
        }
    }
}