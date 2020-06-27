using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using Moq;

namespace ModelStateValidation.Tests
{
    public class ModelStateValidationPostConfigurerSetup
    {
        internal readonly ModelStateValidationPostConfigurer _postConfigurer;
        protected readonly MvcOptions _mvcOptions;

        public ModelStateValidationPostConfigurerSetup()
        {
            _mvcOptions = new MvcOptions();
            var options = new Mock<IOptions<MvcDataAnnotationsLocalizationOptions>>().Object;
            var validationAttributeAdapterProvider = new Mock<ValidationAttributeAdapterProvider>().Object;

            _postConfigurer = new ModelStateValidationPostConfigurer(validationAttributeAdapterProvider, options);
        }
    }
}