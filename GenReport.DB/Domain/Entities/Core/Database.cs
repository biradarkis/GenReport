using CoreDdd.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.DB.Domain.Entities.Core
{
    /// <summary>
    /// Represents a database entity.
    /// </summary>
    [Table("databases")]
    public class Database : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Column("name")]
        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the database provider (e.g., MySQL, PostgreSQL).
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("type")]
        public required string Type { get; set; } 

        /// <summary>
        /// Gets or sets the connection string for the database.
        /// </summary>
        [Required]
        [Column("connection_string")]
        public required string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the server address of the database.
        /// </summary>
        [Column("server_address")]
        [StringLength(255)]
        public required string ServerAddress { get; set; }

        /// <summary>
        /// Gets or sets the port number of the database.
        /// </summary>
        [Column("port")]
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the username for accessing the database.
        /// </summary>
        [Column("username")]
        [StringLength(255)]
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for accessing the database.
        /// </summary>
        [Column("password")]
        [StringLength(255)]
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the database.
        /// </summary>
        [Column("created_at")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified date of the database.
        /// </summary>
        [Column("updated_at")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the status of the database (e.g., active, inactive).
        /// </summary>
        [Column("status")]
        [Required]
        [StringLength(50)]
        public required string Status { get; set; }

        /// <summary>
        /// Gets or sets the description of the database.
        /// </summary>
        [Column("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the database size in bytes.
        /// </summary>
        [Column("size_in_bytes")]
        public required long SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the backup schedule of the database in minutes. 
        /// </summary>
        [Column("backup_schedule")]
        public int BackupSchedule { get; set; }

        /// <summary>
        /// Gets or sets the retention policy for backups.
        /// </summary>
        [Column("backup_retention_policy")]
        public string? BackupRetentionPolicy { get; set; }

        /// <summary>
        /// Gets or sets the encryption method used for the database.
        /// </summary>
        [Column("encryption_method")]
        public string? EncryptionMethod { get; set; }

        /// <summary>
        /// Gets or sets the security level of the database.
        /// </summary>
        [Column("security_level")]
        public string? SecurityLevel { get; set; }
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public DbProvider DbProvider { get; set; }
        public long DbProviderId { get; set; }

    }
}