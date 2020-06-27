using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace ModelStateValidation.Tests
{
    public class ModelStateValidatorTests : BaseModelStateValidatorSetup
    {
        private const string SOME_CRAZY_STRING = "SomeCrazyStringLol";

        [Fact]
        public void NotPassWithNullString()
        {
            var model = new RequiredModel();

            NotPass(model);
        }

        [Fact]
        public void NotPassWithRequiredEmptyString()
        {
            var model = new RequiredModel()
            {
                Summary = string.Empty,
            };

            NotPass(model);
        }

        [Fact]
        public void PassWithNotRequiredEmptyString()
        {
            var model = new EmptyRequiredModel()
            {
                Summary = string.Empty,
            };

            Pass(model);
        }

        [Fact]
        public void NotPassWithNotRequiredEmptyNullString()
        {
            var model = new EmptyRequiredModel();

            NotPass(model);
        }

        [Fact]
        public void NotPassEmail()
        {
            var model = new EmailAddressModel()
            {
                Email = SOME_CRAZY_STRING,
            };

            NotPass(model);
        }

        [Fact]
        public void PassEmail()
        {
            var model = new EmailAddressModel()
            {
                Email = "sample@somedomain.com",
            };

            Pass(model);
        }

        [Fact]
        public void NotPassCreditCard()
        {
            var model = new CreditCardModel()
            {
                CreditCard = SOME_CRAZY_STRING,
            };

            NotPass(model);
        }

        [Fact]
        public void PassCreditCard()
        {
            var model = new CreditCardModel()
            {
                CreditCard = "378282246310005",
            };

            Pass(model);
        }

        [Fact]
        public void NotPassCompare()
        {
            var model = new CompareModel()
            {
                Password = SOME_CRAZY_STRING,
                PasswordConfirmation = $"{SOME_CRAZY_STRING}{SOME_CRAZY_STRING}"
            };

            NotPass(model);
        }

        [Fact]
        public void PassCompare()
        {
            var model = new CompareModel()
            {
                Password = SOME_CRAZY_STRING,
                PasswordConfirmation = SOME_CRAZY_STRING
            };

            Pass(model);
        }

        [Fact]
        public void NotPassPhone()
        {
            var model = new PhoneModel()
            {
                Phone = SOME_CRAZY_STRING,
            };

            NotPass(model);
        }

        [Fact]
        public void PassPhone()
        {
            var model = new PhoneModel()
            {
                Phone = "(123) 234-2342",
            };

            Pass(model);
        }

        [Fact]
        public void NotPassMinimumRange()
        {
            var model = new RangeModel
            {
                Volume = -1,
            };

            NotPass(model);
        }

        [Fact]
        public void NotPassMaximumRange()
        {
            var model = new RangeModel()
            {
                Volume = 101,
            };

            NotPass(model);
        }

        [Fact]
        public void PassRange()
        {
            var model = new RangeModel()
            {
                Volume = 50,
            };

            Pass(model);
        }

        [Fact]
        public void NotPassRegex()
        {
            var model = new RegexModel()
            {
                Text = SOME_CRAZY_STRING,
            };

            NotPass(model);
        }

        [Fact]
        public void PassRegex()
        {
            var model = new RegexModel()
            {
                Text = "11112222",
            };

            Pass(model);
        }

        [Fact]
        public void NotPassStringLength()
        {
            var model = new StringLengthModel()
            {
                Text = SOME_CRAZY_STRING,
            };

            NotPass(model);
        }

        [Fact]
        public void PassStringLength()
        {
            var model = new StringLengthModel()
            {
                Text = "1234",
            };

            Pass(model);
        }

        [Fact]
        public void NotPassUrl()
        {
            var model = new UrlModel
            {
                Url = SOME_CRAZY_STRING,
            };

            NotPass(model);
        }

        [Fact]
        public void PassUrl()
        {
            var model = new UrlModel
            {
                Url = "https://somedomain.com",
            };

            Pass(model);
        }

        [Fact]
        public void NotPassComplexModel()
        {
            var model = new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // won't pass
                Model = new RequiredModel
                {
                    Summary = string.Empty,
                },
            };

            NotPass(model);
        }

        [Fact]
        public void PassComplexModel()
        {
            var model = new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            };

            Pass(model);
        }

        [Fact]
        public void NotPassEnumerable()
        {
            var models = new List<ComplexModel>();

            models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            });
            models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // won't pass
                Model = new RequiredModel
                {
                    Summary = string.Empty,
                },
            });

            NotPass(models);
        }

        [Fact]
        public void PassEnumerable()
        {
            var models = new List<ComplexModel>();

            models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            });
            models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            });

            Pass(models);
        }

        [Fact]
        public void NotPassModelWithEnumerable()
        {
            var model = new EnumerableModel
            {
                Models = new List<ComplexModel>(),
            };
            model.Models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            });
            model.Models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // won't pass
                Model = new RequiredModel
                {
                    Summary = string.Empty,
                },
            });

            NotPass(model);
        }

        [Fact]
        public void PassModelWithEnumerable()
        {
            var model = new EnumerableModel
            {
                Models = new List<ComplexModel>(),
            };
            model.Models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            });
            model.Models.Add(new ComplexModel
            {
                // will pass
                FirstSummary = SOME_CRAZY_STRING,
                // will pass
                Model = new RequiredModel
                {
                    Summary = SOME_CRAZY_STRING,
                },
            });

            Pass(model);
        }
    }
}