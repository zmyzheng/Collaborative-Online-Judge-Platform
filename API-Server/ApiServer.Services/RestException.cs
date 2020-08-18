using System;
using System.Net;

namespace ApiServer.Services
{
    public class RestException: Exception
    {

        public HttpStatusCode Code { get; }
        public override string Message { get; }
        public RestException(HttpStatusCode code, string message = null)
        {
            Code = code;
            Message = message;
        }
    }
}