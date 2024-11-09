using CoreDdd.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenReport.Domain.Entities.Media
{
    /// <summary>
    /// This class represents a media file stored in the system.
    /// </summary>
    [Table("mediafiles")] // Table name mapping
    public class MediaFile : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// The URL where the media file is stored.
        /// </summary>
        [Column("storage_url")] // Column name mapping
        public string? StorageURL { get; set; }

        /// <summary>
        /// The original filename of the media file.
        /// </summary>
        [Column("file_name")] // Column name mapping
        [Required]  // Enforces non-null value
        public required string FileName { get; set; }

        /// <summary>
        /// The MIME type of the media file, indicating its content type.
        /// </summary>
        [Column("mime_type")] // Column name mapping
        [Required]  // Enforces non-null value
        public required string MimeType { get; set; }

        /// <summary>
        /// The size of the media file in bytes.
        /// </summary>
        [Column("size")] // Column name mapping
        public long Size { get; set; }

        /// <summary>
        /// The date and time the media file was created.
        /// </summary>
        [Column("created_at")] // Column name mapping
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Initialize with current UTC time

        /// <summary>
        /// The date and time the media file was last updated.
        /// </summary>
        [Column("updated_at")] // Column name mapping
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Initialize with current UTC time
    }
}