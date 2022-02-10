using Microsoft.AspNetCore.Http;
using SynetecAssessmentApi.Domain.Constants;
using SynetecAssessmentApi.Domain.Errors;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Middleware
{
    public class CustomErrorHandler
    {
        private readonly RequestDelegate _next;
        public CustomErrorHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomAppError ex)
            {
                httpContext.Response.StatusCode = (int)ex.StatusCode;
                await httpContext.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new CustomAppError(ExceptionConstants.CUSTOM_ERROR, context.Response.StatusCode).ToString());
        }
    }
}
