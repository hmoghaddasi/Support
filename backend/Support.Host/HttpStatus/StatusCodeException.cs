using System;
using System.Net;

namespace Support.Host.HttpStatus
{
    public class StatusCodeException : Exception
    {
        public StatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
