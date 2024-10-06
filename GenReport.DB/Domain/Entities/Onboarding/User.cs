using CoreDdd.Domain;
using CoreDdd.Domain.Events;
using GenReport.DB.Domain.Events;
using GenReport.Domain.Entities.Business;
using GenReport.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenReport.Domain.Entities.Onboarding
{
    [Table("users")]
    public class User : Entity<long>, IAggregateRoot, IDeletable
    {
        [NotMapped]
        private PasswordHasher<User> _passwordHasher;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public User(string password, string email, string firstName, string lastName, string? middleName, long organizationId, string profileURL)
        {
            Password = passwordHasher.HashPassword(this, password);
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            OrganizationId = organizationId;
            ProfileURL = profileURL;
        }

        #region Columns

        [NotMapped]
        private PasswordHasher<User> passwordHasher
        {
            get
            {
                return _passwordHasher ??= new PasswordHasher<User>();
            }
        }

        [Column("password")]
        public string Password { get; private set; }

        public bool MatchPassword(string unhashedPassword)
        {
            var result = passwordHasher.VerifyHashedPassword(this, Password, unhashedPassword);
            return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = passwordHasher.HashPassword(this, newPassword);
        }

        [EmailAddress]
        [Column("email")]
        public required string Email { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("last_name")]
        public required string LastName { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }
        public Organization Organization { get; set; }

        [Column("organization_id")]
        public long OrganizationId { get; set; }

        [Column("profile_url")]
        public string? ProfileURL { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        #endregion
        //TODO: Raise doamin event
        public void ForgotPassword()
        {
            DomainEvents.RaiseEvent(new ForgotPasswordEvent { Id = Id });   
        }
    }
}
