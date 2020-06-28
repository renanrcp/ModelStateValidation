using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class DataAnnotationsModelValidatorProviderTests : DataAnnotationsModelValidatorProviderSetup
    {
        [Fact]
        public void CanCreateValidators()
        {
            var context = GetMockedContext();
            _modelValidatorProvider.CreateValidators(context);

            var validatorItems = context.Results;

            var validatorItem = Assert.Single(validatorItems);
            Assert.IsType<ValidatableObjectAdapter>(validatorItem.Validator);
        }

        [Fact]
        public void HasValidatorsPass()
        {
            var attributes = new object[]
            {
                new RequiredAttribute(),
                new MaxLengthAttribute(),
                new BindRequiredAttribute(),
            };

            var result = _modelValidatorProvider.HasValidators(typeof(object), attributes);

            Assert.True(result);
        }

        [Fact]
        public void HasValidatorsNotPass()
        {
            var attributes = new object[]
            {
                new AttributeUsageAttribute(AttributeTargets.All),
            };

            var result = _modelValidatorProvider.HasValidators(typeof(object), attributes);

            Assert.False(result);
        }
    }
}