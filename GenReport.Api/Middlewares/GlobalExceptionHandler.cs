using GenReport.Helpers;
using GenReport.Infrastructure.Interfaces;
using GenReport.Infrastructure.Models.Shared;
using GenReport.Infrastructure.Static.Constants;
using Serilog;

namespace GenReport.Middlewares
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IApplicationConfiguration config) : IEndpointFilter
    {
		private readonly ILogger<GlobalExceptionHandler> _logger = logger;
		

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
			try
			{
				if (config.LogURLs) 
				{
                    Log.Information($"Http Request for baseurl {context.HttpContext.GetBaseUrl()} and endPoint {context.HttpContext.GetEndpoint()}");
                }
				
			  return await next(context);
			}
			catch (Exception e)
			{
				Log.Error(e, $"error executing request for {context.HttpContext.GetRequestUrl()} {e.Message}");
				return new HttpErrorResponse(System.Net.HttpStatusCode.InternalServerError, e.Message, ErrorMessages.MIDDLEWARE_ERROR, [e.Message,"error executing the query from the endpoint class"]);
			}
        }
    }
}
