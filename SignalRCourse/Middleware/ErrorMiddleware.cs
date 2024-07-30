using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace SignalRCourse.Middleware
{
    public class ErrorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (Exception err)
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Response.ContentType = "application/json";
				var pr = new ProblemDetails()
				{
					Status = (int)HttpStatusCode.InternalServerError,
					Title = err.Message,
				};
				await context.Response.WriteAsJsonAsync(pr);
			}
        }
    }
}
