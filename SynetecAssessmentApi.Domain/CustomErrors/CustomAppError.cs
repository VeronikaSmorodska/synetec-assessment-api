using System;
using System.Net;

namespace SynetecAssessmentApi.Domain.Errors
{
    public class CustomAppError : Exception
    {
        public int StatusCode { get; set; }
        public CustomAppError(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = (int)statusCode;
        }
        public CustomAppError(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
        public CustomAppError()
        {
        }
    }
}
