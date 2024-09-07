namespace GenReport.Infrastructure.Interfaces
{
    using GenReport.Domain.Entities.Onboarding;

    /// <summary>
    /// Defines the <see cref="IJWTTokenService" />
    /// </summary>
    public interface IJWTTokenService
    {
        /// <summary>
        /// The GenrateAccessToken
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <param name="jwtSecret">The jwtSecret<see cref="string"/></param>
        /// <param name="expireIn">The expireIn<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string GenrateAccessToken(User user, string jwtSecret, int expireIn);

        /// <summary>
        /// The ValidateToken
        /// </summary>
        /// <param name="token">The token<see cref="string"/></param>
        /// <param name="issuerKey">The issuerKey<see cref="string"/></param>
        /// <returns>The <see cref="Task{(bool Status, string? Message)}"/></returns>
        public Task<(bool Status, string? Message)> ValidateToken(string token, string issuerKey);
    }
}
