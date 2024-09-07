using FastEndpoints;
using GenReport.Domain.DBContext;
using GenReport.Infrastructure.Interfaces;
using GenReport.Infrastructure.Models.HttpRequests.Onboarding;
using GenReport.Infrastructure.Models.Shared;

namespace GenReport.Endpoints.Onboarding
{
    public class Signup(ApplicationDbContext context, IApplicationConfiguration configuration, IJWTTokenService jWTTokenService)  : Endpoint<SignupRequest,Unit>
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IApplicationConfiguration _configuration = configuration;
        private readonly IJWTTokenService jWTTokenService = jWTTokenService;
        public override void Configure()
        {
            Post("/signup");
            AllowAnonymous();
            base.Configure();
        }
        public override Task<HttpResponse<Unit>> HandleAsync(SignupRequest req, CancellationToken ct)
        {
            
        }
    }
}
