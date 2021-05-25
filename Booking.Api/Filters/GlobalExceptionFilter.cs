using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net;
using Booking.Api.Responses;
using Booking.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Booking.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorMessages = context.Exception
                .GetInnerException(new List<string>())
                .ConvertToString();
            
            Log.Error("Error messages: " + errorMessages);
            
            switch (context.Exception)
            {
                case DbException:
                {
                    context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    context.Result = new ObjectResult(new CommonReply<object>(context.Exception));
                    break;
                }
                default:
                {
                    context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Result = new ObjectResult(new CommonReply<object>(context.Exception));
                    break;
                }
            }
            
            context.ExceptionHandled = true;
        }
    }
}