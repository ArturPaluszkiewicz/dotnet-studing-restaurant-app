using System.Diagnostics;

namespace RestaurantApi.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopwatch;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var time = _stopwatch.ElapsedMilliseconds;
            if (time/1000 > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {time} miliseconds";
                _logger.LogInformation(message);
            }
        }
    }
}