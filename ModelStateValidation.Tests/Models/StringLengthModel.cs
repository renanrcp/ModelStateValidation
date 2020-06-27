using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class StringLengthModel
    {
        // Also works with [MaxLength(5)]
        [StringLength(5)]
        public string Text { get; set; }
    }
}