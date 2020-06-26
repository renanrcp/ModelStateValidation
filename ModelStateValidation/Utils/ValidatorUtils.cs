using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;

namespace ModelStateValidation
{
    internal static class ValidatorUtils
    {
        public static ActionContext CreateActionContext()
            => CreateActionContext(new ModelStateDictionary());

        public static ActionContext CreateActionContext(ModelStateDictionary modelState)
            => CreateActionContext(modelState, null);

        public static ActionContext CreateActionContext(ModelStateDictionary modelState, IServiceProvider provider)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            var httpContext = new DefaultHttpContext()
            {
                RequestServices = provider ?? ServiceUtils.GetDefaultServiceProvider(),
            };
            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();

            var actionContext = new ActionContext(httpContext, routeData, actionDescriptor, modelState);

            return actionContext;
        }
    }
}