﻿using GenReport.Infrastructure.Configuration;

namespace GenReport.Infrastructure.Interfaces
{
    /// <summary>
    /// Defines the interface for the application configuration.
    /// </summary>
    public interface IApplicationConfiguration
    {
        /// <summary>
        /// Gets or sets a value indicating whether the database should be created.
        /// </summary>
        public bool CreateDB { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the database should be deleted.
        /// </summary>
        public bool DeleteDB { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the database should be seeded with data.
        /// </summary>
        public bool SeedDB { get; set; }

        /// <summary>
        /// Gets or sets the port number of the application.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the signing key used for issuing access tokens.
        /// </summary>
        public string IssuerSigningKey { get; set; }

        /// <summary>
        /// Gets or sets the refresh key used for issuing refresh tokens.
        /// </summary>
        public string IssuerRefreshKey { get; set; }

        /// <summary>
        /// Gets or sets the expiration time for access tokens (in seconds).
        /// </summary>
        public int AccessTokenExpiry { get; set; }

        /// <summary>
        /// Gets or sets the expiration time for refresh tokens (in seconds).
        /// </summary>
        public int RefreshTokenExpiry { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether URLs should be logged.
        /// </summary>
        public bool LogURLs { get; set; }

        /// <summary>
        /// Gets or sets the configuration settings for connecting to a RabbitMQ server.
        /// </summary>
        public RabbitMQConfiguration RabbitMQConfiguration { get; set; }
    }
}