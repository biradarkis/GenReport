using FastEndpoints;
using GenReport.Domain.DBContext;
using GenReport.Infrastructure.Interfaces;
using GenReport.Infrastructure.Models.HttpRequests.Onboarding;
using GenReport.Infrastructure.Models.HttpResponse.Onboarding;
using GenReport.Infrastructure.Models.Shared;
using GenReport.Infrastructure.Security;
using GenReport.Infrastructure.Static.Constants;
using Microsoft.EntityFrameworkCore;

namespace GenReport.Endpoints.Onboarding
{
    public class Login(ApplicationDbContext context, IApplicationConfiguration configuration , IJWTTokenService jWTTokenService) : Endpoint<LoginRequest, HttpResponse<LoginResponse>>
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IApplicationConfiguration _configuration = configuration;
        private readonly IJWTTokenService jWTTokenService = jWTTokenService;

        public override void Configure()
        {
            Post("/login");
            AllowAnonymous();
            base.Configure();
        }
        public override async Task<HttpResponse<LoginResponse>> HandleAsync(LoginRequest req, CancellationToken ct) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email==req.Email);
            if (user == null)
            {
               return new HttpResponse<LoginResponse>(System.Net.HttpStatusCode.Unauthorized,"Please check email", ErrorMessages.USER_NOT_FOUND, [$"user with email {req.Email} not found"]);
            }
            if (!user.MatchPassword(req.Password))
            {
                return new HttpResponse<LoginResponse>(System.Net.HttpStatusCode.Unauthorized, "Please check password", ErrorMessages.PASSWORD_DOESNT_MATCH, [$"wrong password for email {req.Email} not found"]);
            }
            var token = jWTTokenService.GenrateAccessToken(user,_configuration.IssuerSigningKey,_configuration.AccessTokenExpiry);
            return new HttpResponse<LoginResponse>(new LoginResponse { Token = token} , $"Hi {user.FirstName} {user.LastName}!", System.Net.HttpStatusCode.OK);
        }
    }
}
