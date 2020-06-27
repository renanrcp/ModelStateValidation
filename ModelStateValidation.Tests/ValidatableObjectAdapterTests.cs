using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class ValidatableObjectAdapterTests : ValidatableObjectAdapterSetup
    {
        [Fact]
        public void PassExpectedNames()
        {
            var model = new ValidatableSampleModel();

            var context = GetMockedValidationContextWithContainer(model);

            var results = _adapter.Validate(context);

            Assert.NotNull(results);
            Assert.Empty(results);

            Assert.Equal(nameof(ValidatableSampleModel), model.DisplayName);
            Assert.Null(model.MemberName);
            Assert.Equal(model, model.ObjectInstance);
        }

        [Fact]
        public void ReturnExpectedResults()
        {
            var model = new ValidatableSampleModel();
            var validationResult = new ValidationResult("Error message");
            var modelValidationResult = new ModelValidationResult(null, "Error message");
            var expectedResults = new List<ModelValidationResult>
            {
                modelValidationResult,
            };

            model.ValidationResults.Add(validationResult);

            var context = GetModelValidationContextWithoutContainer(model);

            var results = _adapter.Validate(context);

            Assert.NotNull(results);
            Assert.Equal(expectedResults, results, TestModelValidationResultComparer.Instance);
        }

        private class TestModelValidationResultComparer : IEqualityComparer<ModelValidationResult>
        {
            public static readonly TestModelValidationResultComparer Instance = new TestModelValidationResultComparer();

            private TestModelValidationResultComparer()
            {
            }

            public bool Equals(ModelValidationResult x, ModelValidationResult y)
            {
                if (x == null || y == null)
                {
                    return x == null && y == null;
                }

                return string.Equals(x.MemberName, y.MemberName, StringComparison.Ordinal) &&
                    string.Equals(x.Message, y.Message, StringComparison.Ordinal);
            }

            public int GetHashCode(ModelValidationResult obj)
            {
                if (obj == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }

                return obj.MemberName.GetHashCode();
            }
        }
    }
}