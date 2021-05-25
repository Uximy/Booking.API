using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Booking.Shared
{
    public static class ExceptionExtension
    {
        public static ICollection<string> GetInnerException(this Exception exception, 
            ICollection<string> text)
        {
            if (exception is null)
            {
                return text;
            }
            
            text ??= new List<string>();

            text.Add(exception.Message);
            return exception.InnerException.GetInnerException(text);
        }
        
        public static string ConvertToString(this ICollection<string> errors)
        {
            return errors is not null ? String.Join(";", errors) : "";
        }
    }
}