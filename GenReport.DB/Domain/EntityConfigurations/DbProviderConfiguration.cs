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
            builder.HasData([new DbProvider { Name = "NpgSql" , CreatedAt = DateTime.UtcNow , UpdatedAt = DateTime.UtcNow , DbType = "PostgreSQL" , Language = "C#" }, new DbProvider { Name = "System.Data.SqlClient" , CreatedAt = DateTime.UtcNow , UpdatedAt = DateTime.UtcNow , DbType =  "SQL Server" , Language = "C#" }]);
            builder.HasKey(e => e.Id);
            
        }
    }
}
