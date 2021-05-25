using System.Net;
using System.Security.Authentication;
using Booking.Api.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Booking.Api.Filters
{
    public class AuthorizationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case AuthenticationException:
                {
                    context.HttpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    context.Result = new ObjectResult(new CommonReply<object>(context.Exception));
                    break;
                }
            }

            context.ExceptionHandled = true;
        }
    }
}