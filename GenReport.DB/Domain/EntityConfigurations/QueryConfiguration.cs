using GenReport.DB.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.DB.Domain.EntityConfigurations
{
    public class QueryConfiguration : IEntityTypeConfiguration<Query>
    {
        public void Configure(EntityTypeBuilder<Query> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.CreatedBy).WithMany().HasForeignKey(x=>x.CreatedById).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x=>x.Database).WithMany().HasForeignKey(x=>x.DatabaseId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(x => x.InvolvedTables).IsRequired().HasColumnType("text[]");    
        }
    }
}
