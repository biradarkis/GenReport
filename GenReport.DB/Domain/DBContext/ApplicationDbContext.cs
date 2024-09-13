

using GenReport.DB.Domain.Interfaces;
using GenReport.Domain.Entities.Media;
using GenReport.Domain.Entities.Business;
using GenReport.Domain.Entities.Onboarding;
using Microsoft.EntityFrameworkCore;
using GenReport.Domain.EntityConfigurations;
using GenReport.DB.Domain.EntityConfigurations;
using GenReport.DB.Domain.Entities.Core;

namespace GenReport.Domain.DBContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        #region Users
        public DbSet<User> Users { get; set; }
        #endregion Users

        #region Business
        public DbSet<Organization> Organizations { get; set; }
        #endregion Business

        #region Media
        public DbSet<MediaFile> MediaFiles { get; set; }
        #endregion Media
        #region Core
        public DbSet<Database> Databases { get; set; }
        public DbSet<Query> Queries { get; set; }
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new MediaFileConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
