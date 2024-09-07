using CoreDdd.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenReport.Domain.Entities.Media
{
    [Table("mediafiles")]
    public class MediaFile : Entity<long>, IAggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public MediaFile(string? storageURL, string fileName, string mimeType, long size)
        {
            StorageURL = storageURL;
            FileName = fileName;
            MimeType = mimeType;
            Size = size;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        #region Columns
        [Column("storage_url")]
        public string? StorageURL { get; set; }

        [Column("file_name")]
        public required string FileName { get; set; }

        [Column("mime_type")]
        public required string MimeType { get; set; }

        [Column("size")]
        public long Size { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        #endregion
    }
}
