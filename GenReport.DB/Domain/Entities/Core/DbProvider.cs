using CoreDdd.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.DB.Domain.Entities.Core
{
    /// <summary>
    /// the defualt database provider for connection management
    /// </summary>
    /// <seealso cref="CoreDdd.Domain.Entity<System.Int64>" />
    /// <seealso cref="CoreDdd.Domain.Entity&lt;System.Int64&gt;" />
    /// <seealso cref="CoreDdd.Domain.IAggregateRoot" />
    [Table("dbprovider")]
    public class DbProvider : Entity<long> ,IAggregateRoot
    {
        public required string DbType { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column("name")]
        public required string Name { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public required string Language { get; set; }
    }
}
