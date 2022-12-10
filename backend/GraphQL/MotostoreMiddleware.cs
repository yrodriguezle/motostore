using GraphQL;
using GraphQL.Instrumentation;

using Motostore.Services;

namespace Motostore.GraphQL
{
    public class MotostoreMiddleware : IFieldMiddleware
    {
        private readonly IAuthenticationService _authenticationService;

        public MotostoreMiddleware(Defer<IAuthenticationService> authService)
        {
            _authenticationService = authService.Value;
        }

        public ValueTask<object?> ResolveAsync(IResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            if (context is not null && context.SubFields is not null && !(context.Path.Contains("login") || context.SubFields.ContainsKey("login")))
            {
                if (!_authenticationService.ValidateAccessToken() && context.Errors.Count() == 0)
                {
                    ExecutionError exception = new("Unauthorized");
                    exception.Code = "401";
                    exception.Data["message"] = "Unauthorized";
                    exception.Data["httpCode"] = 401;
                    context.Errors.Add(exception);
                }
            }
            return next(context);
        }
    }
}
