using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class CompareModel
    {
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; }
    }
}