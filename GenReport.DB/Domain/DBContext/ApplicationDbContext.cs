

using GenReport.DB.Domain.Interfaces;
using GenReport.Domain.Entities.Media;
using GenReport.Domain.Entities.Business;
using GenReport.Domain.Entities.Onboarding;
using Microsoft.EntityFrameworkCore;

namespace GenReport.Domain.DBContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
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
    }
}
