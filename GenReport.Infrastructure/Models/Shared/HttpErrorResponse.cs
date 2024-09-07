namespace GenReport.Infrastructure.Models.Shared
{
    using GenReport.Infrastructure.Static.Constants;
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="HttpErrorResponse" />
    /// </summary>
    public class HttpErrorResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether Success
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; } = GenericConstants.DEFAULT_ERROR_MESSAGE;

        /// <summary>
        /// Gets or sets the ErrorCode
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the Errors
        /// </summary>
        public List<string> Errors { get; set; } = [];

        /// <summary>
        /// Gets or sets the Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;


        /// <summary>
        /// Initializes a new instance of the <see cref="HttpErrorResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The statusCode<see cref="HttpStatusCode"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        public HttpErrorResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            ErrorCode = ErrorMessages.DEFAULT_ERROR_CODE;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpErrorResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The statusCode<see cref="HttpStatusCode"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="errorCode">The errorCode<see cref="string"/></param>
        public HttpErrorResponse(HttpStatusCode statusCode, string message, string errorCode)
        {
            StatusCode = statusCode;
            Message = message;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpErrorResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The statusCode<see cref="HttpStatusCode"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="errorCode">The errorCode<see cref="string"/></param>
        /// <param name="errors">The errors<see cref="List{string}"/></param>
        public HttpErrorResponse(HttpStatusCode statusCode, string message, string errorCode, List<string> errors)
        {
            StatusCode = statusCode;
            Message = message;
            ErrorCode = errorCode;
            Errors = errors;
        }

        /// <summary>
        /// The AddError
        /// </summary>
        /// <param name="error">The error<see cref="string"/></param>
        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
