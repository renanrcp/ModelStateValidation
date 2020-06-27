using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Tests
{
    public class UrlModel
    {
        [Url]
        public string Url { get; set; }
    }
}