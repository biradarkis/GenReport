namespace GenReport.Infrastructure.Models.HttpResponse.Onboarding
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Defines the <see cref="LoginResponse" />
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets the Token
        /// </summary>
        [JsonPropertyName("token")]
        public required string Token { get; set; }

        /// <summary>
        /// Gets or sets the RefreshToken
        /// </summary>
        [JsonPropertyName("refreshtoken")]
        public required string RefreshToken { get; set; }
    }
}
