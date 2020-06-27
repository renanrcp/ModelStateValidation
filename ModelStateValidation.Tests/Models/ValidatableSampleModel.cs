using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class ValidatableSampleModel : IValidatableObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; private set; }

        public string MemberName { get; private set; }

        public object ObjectInstance { get; private set; }

        public IList<ValidationResult> ValidationResults { get; } = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DisplayName = validationContext.DisplayName;
            MemberName = validationContext.MemberName;
            ObjectInstance = validationContext.ObjectInstance;

            return ValidationResults;
        }
    }
}