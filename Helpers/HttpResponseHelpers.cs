using GenReport.Infrastructure.Models;
using GenReport.Infrastructure.Models.Shared;
using GenReport.Infrastructure.Static.Constants;
using System.Net;

namespace GenReport.Helpers
{
    public class HttpResponseHelpers
    {
        private static Action<HttpContext> sendTokenExpiredResponse = (HttpContext httpcontext) =>
        {
            httpcontext.Response.Headers.Append(GenericConstants.TOKEN_EXPIRED_HEADER, "true");
            httpcontext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var response = new HttpErrorResponse(HttpStatusCode.Unauthorized, "", ErrorMessages.TOKEN_EXPIRED);
            response.AddError($"the token generated has expired please use the refresh token and URL: {UrlHelper.GetBaseUrl(httpcontext)}/refresh to generate a new token.");
        };

        public static Action<HttpContext> SendTokenExpiredResponse { get => sendTokenExpiredResponse; set => sendTokenExpiredResponse = value; }
        public static Action<HttpContext> SendInvalidTokenResponse { get => sendInvalidTokenResponse; set => sendInvalidTokenResponse = value; }

        private static Action<HttpContext> sendInvalidTokenResponse = (HttpContext httpContext) =>
        {
            httpContext.Response.Headers.Append(GenericConstants.INVALID_TOKEN_HEADER, "true");
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var response = new HttpErrorResponse(HttpStatusCode.Unauthorized, "", ErrorMessages.TOKEN_NOT_VALID);
            response.AddError($"the token is invalid please check credentials");

        };
        public static Action<HttpContext> AddUserToContext { get => addUserToContext; set => addUserToContext = value; }

        private static Action<HttpContext> addUserToContext = (HttpContext httpContext) => 
        {
            throw new NotImplementedException();
        };
    }
}
