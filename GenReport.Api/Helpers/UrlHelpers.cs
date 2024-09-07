namespace GenReport.Helpers
{
    using Microsoft.AspNetCore.Http;

    public class UrlHelper
    {
        public static string GetRequestUrl(HttpContext httpContext)
        {
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}";
        }
        public static string GetBaseUrl(HttpContext httpContext)
        {
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
        }
    }
}
