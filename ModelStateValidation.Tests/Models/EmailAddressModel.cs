using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class EmailAddressModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}