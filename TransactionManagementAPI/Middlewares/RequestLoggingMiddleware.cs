namespace TransactionManagementAPI.Middlewares;

// Middleware to log each incoming HTTP request.
// This class captures the details about the request and logs them.
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    // Constructor: injects the next delegate in the pipeline and a logger instance.
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    // Middleware's main method. This is where the logging of requests happens.
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Log the incoming request details such as method and path.
            _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline.
            await _next(context);

            // Log additional information after the request is handled, if needed.
            _logger.LogInformation("Finished handling request.");
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur while processing the request.
            _logger.LogError(ex, "An error occurred while handling request.");

            // Re-throw the exception to let it propagate in the pipeline.
            throw;
        }
    }
}