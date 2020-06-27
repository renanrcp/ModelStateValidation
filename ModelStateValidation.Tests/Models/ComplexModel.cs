using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class ComplexModel
    {
        [Required]
        public string FirstSummary { get; set; }

        [Required]
        public RequiredModel Model { get; set; }
    }
}