using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ModelStateValidation.Tests
{
    public class CompositeModel
    {
        [Required]
        [DisplayName("TestName")]
        public string Value { get; set; }

        public void ValueMethod([Bind] string id)
        { }
    }
}