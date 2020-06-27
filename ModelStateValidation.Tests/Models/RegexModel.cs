using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class RegexModel
    {
        [RegularExpression(@"^([0-9]{8})$")]
        public string Text { get; set; }
    }
}