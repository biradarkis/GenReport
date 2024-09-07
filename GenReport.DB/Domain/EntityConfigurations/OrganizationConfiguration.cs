using GenReport.Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenReport.Domain.EntityConfigurations
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        /// <summary>
        /// Organization Configuration 
        /// sets the primary key constraint 
        /// creates an index on name 
        /// sets the cascade delete behaviour on
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.HasMany(x=>x.Users).WithOne(x=>x.Organization).HasForeignKey(x=>x.OrganizationId).OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(x => !x.IsDeleted);
             
        }
    }
}
