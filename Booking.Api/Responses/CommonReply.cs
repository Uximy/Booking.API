using System;
using System.Collections.Generic;
using Booking.Dto;
using Booking.Shared;
using Newtonsoft.Json;

namespace Booking.Api.Responses
{
    public class CommonReply<TModel>
    {
        [JsonProperty("errors")]
        public ICollection<string> Errors { get; set; }
        
        public TModel Body { get; set; }

        public CommonReply()
        {
            Errors = null;
        }

        public CommonReply(TModel body)
        {
            Body = body;
            Errors = null;
        }

        public CommonReply(Exception exception)
        {
            Errors = exception.GetInnerException(Errors);
        }
    }
}