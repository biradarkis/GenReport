using GenReport.DB.Domain.Interfaces;
using GenReport.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenReport.DB.Domain.Seed
{
    public partial class ApplicationDBContextSeeder(IApplicationDbContext applicationDbContext) : IApplicationSeeder
    {
        private readonly IApplicationDbContext applicationDbContext = applicationDbContext;

        public async Task Seed()
        {
           await SeedOrganizations();
           await SeedUsers();
           await SeedMediaFiles();
        }
    }
}
