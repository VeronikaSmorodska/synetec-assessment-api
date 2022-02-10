﻿using System;
using System.Net;

namespace SynetecAssessmentApi.Domain.Errors
{
    public class CustomAppError : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public CustomAppError(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = (int)statusCode;
        }
        public CustomAppError(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public CustomAppError()
        {
        }
    }
}
