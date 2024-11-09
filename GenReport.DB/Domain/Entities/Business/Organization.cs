using CoreDdd.Domain;
using GenReport.Domain.Entities.Onboarding;
using GenReport.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenReport.Domain.Entities.Business
{
    [Table("organization")]
    public class Organization : Entity<long> , IAggregateRoot , IDeletable
    {
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public Organization(string name, DateTime createdAt, DateTime updatedAt)
        {
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Users = [];
            
        }

        #region Columns
        [Column("name")]
        public required string Name { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get;set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get;set; }
        [NotMapped]
        public ICollection<User> Users { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
        #endregion
    }

}
