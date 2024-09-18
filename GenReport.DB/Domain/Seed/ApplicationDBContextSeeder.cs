﻿namespace GenReport.DB.Domain.Seed
{
    using GenReport.Domain.DBContext;
    using GenReport.Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Serilog;
    using System.Globalization;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ApplicationDBContextSeeder" />
    /// </summary>
    /// <seealso cref="GenReport.Domain.Interfaces.IApplicationSeeder" />
    public partial class ApplicationDBContextSeeder(ApplicationDbContext applicationDbContext) : IApplicationSeeder
    {
        /// <summary>
        /// Defines the applicationDbContext
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        private readonly ILogger logger;

        /// <summary>
        /// The Seed
        /// </summary>
        /// <returns>
        /// The <see cref="Task" />
        /// </returns>
        public async Task Seed()
        {
            await SeedOrganizations();
            await SeedUsers();
            await SeedMediaFiles();
        }
        /// <summary>
        /// Seeds the mandatory tables.
        /// </summary>
        public async Task SeedMandatoryTables()
        {
            await SeedDbProviders();
            
        }

        public async Task RunScripts()
        {
           var root =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException("Invalid folder for sql files");
            using var  sqltransaction = applicationDbContext.Database.BeginTransaction();
            try   
            {
                foreach (var file in Directory.GetFiles(root))
                {
                    if (file.EndsWith(".sql", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var sql = await File.ReadAllTextAsync(file);
                        await applicationDbContext.Database.ExecuteSqlRawAsync(sql);
                    }
                }
              await  sqltransaction.CommitAsync() ;
            }
            catch (Exception e)
            {
                logger.Error(e, $"TAG - {nameof(ApplicationDBContextSeeder)} error executing neccessary sql files {e.Message}");
                await sqltransaction.RollbackAsync() ;
            }
     
        }
    }
}
