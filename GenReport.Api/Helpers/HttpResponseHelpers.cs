using GenReport.Infrastructure.Models;
using GenReport.Infrastructure.Models.Shared;
using GenReport.Infrastructure.Static.Constants;
using System.Net;

namespace GenReport.Helpers
{
    /// <summary>
    /// Helper functions for httpResponse
    /// </summary>
    public class HttpResponseHelpers
    {
        /// <summary>
        /// The send token expired response
        /// </summary>
        private static Action<HttpContext> sendTokenExpiredResponse = (HttpContext httpcontext) =>
        {
            httpcontext.Response.Headers.Append(GenericConstants.TOKEN_EXPIRED_HEADER, "true");
            httpcontext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var response = new HttpErrorResponse(HttpStatusCode.Unauthorized, "", ErrorMessages.TOKEN_EXPIRED);
            response.AddError($"the token generated has expired please use the refresh token and URL: {httpcontext.GetBaseUrl()}/refresh to generate a new token.");
        };

        /// <summary>
        /// Gets or sets the send token expired response.
        /// </summary>
        /// <value>
        /// The send token expired response.
        /// </value>
        public static Action<HttpContext> SendTokenExpiredResponse { get => sendTokenExpiredResponse; set => sendTokenExpiredResponse = value; }
        /// <summary>
        /// Gets or sets the send invalid token response.
        /// </summary>
        /// <value>
        /// The send invalid token response.
        /// </value>
        public static Action<HttpContext> SendInvalidTokenResponse { get => sendInvalidTokenResponse; set => sendInvalidTokenResponse = value; }

        /// <summary>
        /// The send invalid token response
        /// </summary>
        private static Action<HttpContext> sendInvalidTokenResponse = (HttpContext httpContext) =>
        {
            httpContext.Response.Headers.Append(GenericConstants.INVALID_TOKEN_HEADER, "true");
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var response = new HttpErrorResponse(HttpStatusCode.Unauthorized, "", ErrorMessages.TOKEN_NOT_VALID);
            response.AddError($"the token is invalid please check credentials");

        };
        /// <summary>
        /// Gets or sets the add user to context.
        /// </summary>
        /// <value>
        /// The add user to context.
        /// </value>
        public static Action<HttpContext> AddUserToContext { get => addUserToContext; set => addUserToContext = value; }

        /// <summary>
        /// The add user to context
        /// </summary>
        private static Action<HttpContext> addUserToContext = (HttpContext httpContext) => 
        {
            throw new NotImplementedException();
        };
    }
}
