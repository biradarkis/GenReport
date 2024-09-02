namespace GenReport
{
    using FastEndpoints;
    using GenReport.DB.Domain.Seed;
    using GenReport.Domain.DBContext;
    using GenReport.Domain.Interfaces;
    using GenReport.Helpers;
    using GenReport.Infrastructure.Configuration;
    using GenReport.Infrastructure.Interfaces;
    using GenReport.Services.Implementations;
    using GenReport.Services.Interfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="Startup" />
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Startup"/> class.
    /// </remarks>
    /// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
    public class Startup(IConfiguration configuration)
    {

        /// <summary>
        /// The ConfigureServices
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ApplicationConfiguration ApplicationConfiguration = new();
            Configuration.GetSection("Configuration").Bind(ApplicationConfiguration);
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("GenReportPostgres"), npgSqlOptions => npgSqlOptions.CommandTimeout(ApplicationConfiguration.CommandTimeOut)));
            services.AddFastEndpoints();
            services.AddAuthentication();
            services.AddSingleton<IApplicationConfiguration>(ApplicationConfiguration);
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IApplicationSeeder, ApplicationDBContextSeeder>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => 
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ApplicationConfiguration.IssuerSigningKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    SaveSigninToken = false,
                    RequireExpirationTime = true,
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = res =>
                    {
                        HttpResponseHelpers.AddUserToContext(res.HttpContext);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = err =>
                    {
                        if (err.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            HttpResponseHelpers.SendTokenExpiredResponse(err.HttpContext);
                        }
                        return Task.CompletedTask;
                    },
                    OnForbidden = req =>
                    {
                        HttpResponseHelpers.SendInvalidTokenResponse(req.HttpContext);
                        return Task.CompletedTask;
                    }

                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Grepo",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jhfdkj.jkdsakjdsa.jkdsajk\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
        });
       });

        }

        /// <summary>
        /// Gets the Configuration
        /// </summary>
        public IConfiguration Configuration { get; } = configuration;

        /// <summary>
        /// The Configure
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <param name="env">The env<see cref="IWebHostEnvironment"/></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseFastEndpoints();
            
        }

        /// <summary>
        /// The CreateDB
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public static async Task CreateDB(IApplicationBuilder app)
        {
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            await app.ApplicationServices.GetService<ApplicationDbContext>()?.Database?.EnsureCreatedAsync(default);
        }

        /// <summary>
        /// The SeedDB
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public static async Task SeedDB(IApplicationBuilder app)
        {
            var seeder = app.ApplicationServices.GetService<IApplicationSeeder>();
            await seeder.Seed();
        }

        /// <summary>
        /// The DeleteDB
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public static async Task DeleteDB(IApplicationBuilder app)
        {
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            await app.ApplicationServices.GetService<ApplicationDbContext>()?.Database?.EnsureDeletedAsync(default);
        }
    }
}
