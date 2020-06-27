using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class EmptyRequiredModel
    {
        [Required(AllowEmptyStrings = true)]
        public string Summary { get; set; }
    }
}