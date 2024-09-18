using GenReport.DB.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.DB.Domain.Seed
{
    /// <summary>
    /// The Seeder partial class
    /// </summary>
    /// <seealso cref="GenReport.Domain.Interfaces.IApplicationSeeder" />
    public partial class ApplicationDBContextSeeder
    {

        /// <summary>
        /// Seeds the database providers.
        /// </summary>
        public async Task SeedDbProviders()
        {
            applicationDbContext.DbProviders.AddRange([new DbProvider { Name = "NpgSql", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DbType = "PostgreSQL", Language = "C#" }, new DbProvider { Name = "System.Data.SqlClient", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, DbType = "SQL Server", Language = "C#" }]);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
