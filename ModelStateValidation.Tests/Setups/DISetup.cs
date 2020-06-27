using System;

namespace ModelStateValidation.Tests
{
    public abstract class DISetup
    {
        protected readonly IServiceProvider _provider;

        protected DISetup()
        {
            _provider = ServiceUtils.GetDefaultServiceProvider();
        }
    }
}