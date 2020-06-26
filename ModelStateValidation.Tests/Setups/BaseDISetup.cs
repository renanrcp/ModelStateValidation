using System;

namespace ModelStateValidation.Tests
{
    public abstract class BaseDISetup
    {
        protected readonly IServiceProvider _provider;

        public BaseDISetup()
        {
            _provider = ServiceUtils.GetDefaultServiceProvider();
        }
    }
}