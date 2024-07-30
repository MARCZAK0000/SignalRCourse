namespace SignalRCourse.Middleware
{
    public class TransactionMiddlerware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
