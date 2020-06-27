using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class RangeModel
    {
        [Range(0, 100)]
        public int Volume { get; set; }
    }
}