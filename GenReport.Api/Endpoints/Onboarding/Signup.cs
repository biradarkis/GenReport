using FastEndpoints;
using GenReport.Domain.DBContext;
using GenReport.Infrastructure.Interfaces;
using GenReport.Infrastructure.Models.HttpRequests.Onboarding;
using GenReport.Infrastructure.Models.Shared;
using GenReport.Infrastructure.Static.Constants;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace GenReport.Endpoints.Onboarding
{
    public class Signup(ApplicationDbContext context, IApplicationConfiguration configuration, IJWTTokenService jWTTokenService)  : Endpoint<SignupRequest,HttpResponse<Unit>>
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IApplicationConfiguration _configuration = configuration;
        private readonly IJWTTokenService jWTTokenService = jWTTokenService;
        public override void Configure()
        {
            Post("/signup");
            AllowAnonymous();
            
        }
        public override async Task HandleAsync(SignupRequest req, CancellationToken ct)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x=>x.Email==req.Email,ct);
            if (existingUser != null) 
            {
              await  SendAsync(new HttpResponse<Unit>(System.Net.HttpStatusCode.Conflict,"please try using a different email", ErrorMessages.USER_ALREADY_EXISTS, [$"user with email {req.Email} already exists"]), cancellation: ct);
              return;
            }
            var defaultOrganizationId = await _context.Organizations.Select(x => x.Id).FirstOrDefaultAsync(ct);
            _context.Users.Add(new Domain.Entities.Onboarding.User(req.Password,req.Email,req.FirstName ,req.LastName , req.MiddleName , defaultOrganizationId,string.Empty));
            await _context.SaveChangesAsync(ct);
            await SendAsync(new HttpResponse<Unit>(Unit.Value), cancellation: ct);
        }
    }
}
