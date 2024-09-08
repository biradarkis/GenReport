namespace GenReport.DB.Domain.Seed
{
    using GenReport.Domain.DBContext;
    using GenReport.Domain.Interfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ApplicationDBContextSeeder" />
    /// </summary>
    public partial class ApplicationDBContextSeeder(ApplicationDbContext applicationDbContext) : IApplicationSeeder
    {
        /// <summary>
        /// Defines the applicationDbContext
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;

        /// <summary>
        /// The Seed
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Seed()
        {
            await SeedOrganizations();
            await SeedUsers();
            await SeedMediaFiles();
        }
    }
}
