namespace GenReport.Domain.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IApplicationSeeder" />
    /// </summary>
    public interface IApplicationSeeder
    {
        /// <summary>
        /// The Seed method to seed the DB
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        public Task Seed();
        public Task SeedMandatoryTables();
        public Task RunScripts();
    }
}
