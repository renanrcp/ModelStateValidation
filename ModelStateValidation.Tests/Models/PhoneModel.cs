using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class PhoneModel
    {
        [Phone]
        public string Phone { get; set; }
    }
}