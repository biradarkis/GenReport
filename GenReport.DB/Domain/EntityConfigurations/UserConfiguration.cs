using GenReport.Domain.Entities.Onboarding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenReport.Domain.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// User Configuration 
        /// sets the primary key constraint 
        /// creates an index on firstname , lastname , email
        /// sets the cascade delete behaviour on
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Organization).WithMany(x => x.Users).HasForeignKey(x=>x.OrganizationId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}
