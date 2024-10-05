using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.Infrastructure.Configuration
{
    /// <summary>
    /// Represents the configuration settings for connecting to a RabbitMQ server.
    /// </summary>
    public class RabbitMQConfiguration
    {
        /// <summary>
        /// Gets or sets the hostname of the RabbitMQ server.
        /// </summary>
        public required string HostName { get; set; }

        /// <summary>
        /// Gets or sets the port number of the RabbitMQ server.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the username used to authenticate with the RabbitMQ server.
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password used to authenticate with the RabbitMQ server.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the client-provided name used for the connection.
        /// </summary>
        public string? ClientProvidedName { get; set; }
    }
}