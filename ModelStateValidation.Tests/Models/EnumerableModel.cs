using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class EnumerableModel
    {
        [Required]
        public List<ComplexModel> Models { get; set; }
    }
}