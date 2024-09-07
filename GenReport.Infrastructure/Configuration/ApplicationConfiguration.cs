namespace GenReport.Infrastructure.Configuration
{
    using GenReport.Infrastructure.Interfaces;

    /// <summary>
    /// Defines the <see cref="ApplicationConfiguration" />
    /// </summary>
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        /// <summary>
        /// Gets or sets a value indicating whether CreateDB
        /// </summary>
        public bool CreateDB { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether DeleteDB
        /// </summary>
        public bool DeleteDB { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SeedDB
        /// </summary>
        public bool SeedDB { get; set; }

        /// <summary>
        /// Gets or sets the Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the CommandTimeOut
        /// </summary>
        public int CommandTimeOut { get; set; }

        /// <summary>
        /// Gets or sets the IssuerSigningKey
        /// </summary>
        public string IssuerSigningKey { get; set; } = "";

        /// <summary>
        /// Gets or sets the IssuerRefreshKey
        /// </summary>
        public string IssuerRefreshKey { get; set; } = "";

        /// <summary>
        /// Gets or sets the AccessTokenExpiry
        /// </summary>
        public int AccessTokenExpiry { get; set; }

        /// <summary>
        /// Gets or sets the RefreshTokenExpiry
        /// </summary>
        public int RefreshTokenExpiry { get; set; }
    }
}
