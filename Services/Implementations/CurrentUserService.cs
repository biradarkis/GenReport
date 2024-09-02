namespace GenReport.Services.Implementations
{
    using GenReport.Services.Interfaces;
    using System.Security.Claims;

    /// <summary>
    /// Defines the <see cref="CurrentUserService" />
    /// </summary>
    public class CurrentUserService(IHttpContextAccessor _context) : ICurrentUserService
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly IHttpContextAccessor _context = _context;

        /// <summary>
        /// The IsAuthenticated
        /// </summary>
        /// <returns>The <see cref="bool"/>true if authenticated false otherwise </returns>
        public bool IsAuthenticated()
        {
            return _context.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        /// <summary>
        /// The LoggedInUserId
        /// </summary>
        /// <returns>The <see cref="long?"/>Current User Id if authenticated null otherwise </returns>
        public long? LoggedInUserId()
        {
            string? userIdStr = _context.HttpContext?.User?.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userIdStr != null ? long.Parse(userIdStr) : null;
        }

        /// <summary>
        /// Gets The LoggedInUserName
        /// </summary>
        /// <returns>The <see cref="string?"/>Current User Name if authenticated null otherwise </returns>
        public string? LoggedInUserName()
        {
            return _context.HttpContext?.User?.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }
    }
}
