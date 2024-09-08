namespace GenReport.DB.Domain.Seed
{
    using GenReport.Domain.Entities.Onboarding;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ApplicationDBContextSeeder" />
    /// </summary>
    public partial class ApplicationDBContextSeeder
    {
        /// <summary>
        /// The SeedUsers
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        public async Task SeedUsers()
        {
            var orgaizationIds = await applicationDbContext.Organizations.Select(x => x.Id).ToListAsync();
           var users  =  Enumerable.Range(0, 50).Select(x => new User(
                email: Faker.Internet.Email(),
                firstName: Faker.Name.First(),
                lastName: Faker.Name.Last(),
                middleName: Faker.Name.Middle(),
                profileURL: Faker.Internet.SecureUrl(),
                organizationId: orgaizationIds[Faker.RandomNumber.Next(orgaizationIds.Count-1)], password: "Kris#0808")).ToList();
            applicationDbContext.Users.AddRange(users);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
