namespace GenReport.Endpoints.Onboarding
{
    using FastEndpoints;
    using GenReport.Domain.DBContext;
    using GenReport.Infrastructure.Interfaces;
    using GenReport.Infrastructure.Models.HttpRequests.Onboarding;
    using GenReport.Infrastructure.Models.HttpResponse.Onboarding;
    using GenReport.Infrastructure.Models.Shared;
    using GenReport.Infrastructure.Static.Constants;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="Login" />
    /// </summary>
    public class Login(ApplicationDbContext context, IApplicationConfiguration configuration, IJWTTokenService jWTTokenService) : Endpoint<LoginRequest, HttpResponse<LoginResponse>>
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext _context = context;

        /// <summary>
        /// Defines the _configuration
        /// </summary>
        private readonly IApplicationConfiguration _configuration = configuration;

        /// <summary>
        /// Defines the jWTTokenService
        /// </summary>
        private readonly IJWTTokenService jWTTokenService = jWTTokenService;

        /// <summary>
        /// The Configure
        /// </summary>
        public override void Configure()
        {
            Post("/login");
            AllowAnonymous();
            base.Configure();
        }

        /// <summary>
        /// The HandleAsync
        /// </summary>
        /// <param name="req">The req<see cref="LoginRequest"/></param>
        /// <param name="ct">The ct<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task{HttpResponse{LoginResponse}}"/></returns>
        public override async Task<HttpResponse<LoginResponse>> HandleAsync(LoginRequest req, CancellationToken ct)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == req.Email);
            if (user == null)
            {
                return new HttpResponse<LoginResponse>(System.Net.HttpStatusCode.Unauthorized, "Please check email", ErrorMessages.USER_NOT_FOUND, [$"user with email {req.Email} not found"]);
            }
            if (!user.MatchPassword(req.Password))
            {
                return new HttpResponse<LoginResponse>(System.Net.HttpStatusCode.Unauthorized, "Please check password", ErrorMessages.PASSWORD_DOESNT_MATCH, [$"wrong password for email {req.Email} not found"]);
            }
            var token = jWTTokenService.GenrateAccessToken(user, _configuration.IssuerSigningKey, _configuration.AccessTokenExpiry);
            var refreshToken = jWTTokenService.GenrateAccessToken(user, _configuration.IssuerRefreshKey, _configuration.RefreshTokenExpiry);
            return new HttpResponse<LoginResponse>(new LoginResponse { Token = token, RefreshToken = refreshToken }, $"Hi {user.FirstName} {user.LastName}!", System.Net.HttpStatusCode.OK);
        }
    }
}
