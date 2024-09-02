namespace GenReport.Services.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ICurrentUserService" />
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// The IsAuthenticated
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool IsAuthenticated();

        /// <summary>
        /// The LoggedInUserId
        /// </summary>
        /// <returns>The <see cref="long?"/></returns>
        public long? LoggedInUserId();

        /// <summary>
        /// The LoggedInUserName
        /// </summary>
        /// <returns>The <see cref="string?"/></returns>
        public string? LoggedInUserName();
    }
}
