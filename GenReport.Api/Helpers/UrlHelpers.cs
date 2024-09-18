namespace GenReport.Helpers
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// UrlHelper extensions
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// Gets the request URL.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static string GetRequestUrl( this HttpContext httpContext)
        {
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}";
        }
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static string GetBaseUrl(this HttpContext httpContext)
        {
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
        }
    }
}
