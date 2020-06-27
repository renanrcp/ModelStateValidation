using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class CreditCardModel
    {
        [CreditCard]
        public string CreditCard { get; set; }
    }
}