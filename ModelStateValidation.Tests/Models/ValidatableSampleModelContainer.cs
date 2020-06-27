using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class ValidatableSampleModelContainer
    {
        [Display(Name = "sample model")]
        public ValidatableSampleModel SampleModelWithDisplay { get; set; }

        public ValidatableSampleModel SampleModel { get; set; }
    }
}