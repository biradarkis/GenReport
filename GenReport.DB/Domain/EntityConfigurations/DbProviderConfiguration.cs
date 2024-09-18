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
    public class DbProviderConfiguration : IEntityTypeConfiguration<DbProvider>
    {
        public void Configure(EntityTypeBuilder<DbProvider> builder)
        {
            builder.HasKey(e => e.Id);   
        }
    }
}
