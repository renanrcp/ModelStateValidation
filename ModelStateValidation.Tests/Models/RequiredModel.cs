using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class RequiredModel
    {
        [Required]
        public string Summary { get; set; }
    }
}