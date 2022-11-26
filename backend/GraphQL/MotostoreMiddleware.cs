using GraphQL;
using GraphQL.Instrumentation;

namespace Motostore.GraphQL
{
    public class MotostoreMiddleware : IFieldMiddleware
    {
        //public async Task Invoke(HttpContext httpContext)
        //{
        //    if (!httpContext.User.Identity.IsAuthenticated)
        //    {
        //        await httpContext.Authentication.ChallengeAsync();
        //        return;
        //    }

        //    await _next(httpContext);
        //}

        public ValueTask<object?> ResolveAsync(IResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            return next(context);
        }
    }
}
