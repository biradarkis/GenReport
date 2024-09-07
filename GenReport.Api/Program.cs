using FastEndpoints;
using FluentValidation;
using GenReport.DB.Domain.Seed;
using GenReport.Domain.DBContext;
using GenReport.Domain.Interfaces;
using GenReport.Helpers;
using GenReport.Infrastructure.Configuration;
using GenReport.Infrastructure.Interfaces;
using GenReport.Infrastructure.Security;
using GenReport.Services.Implementations;
using GenReport.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

// Create a new web application builder
var builder = WebApplication.CreateBuilder(args);

// Configuration setup
var configuration = builder.Configuration;
var applicationConfiguration = new ApplicationConfiguration();
configuration.GetSection("Configuration").Bind(applicationConfiguration);

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("GenReportPostgres"),
        npgSqlOptions => npgSqlOptions.CommandTimeout(applicationConfiguration.CommandTimeOut)));

// Add FastEndpoints
builder.Services.AddFastEndpoints();



// Add API Explorer for Swagger
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation
builder.Services.AddSwaggerGen();


// Register custom services
builder.Services.AddSingleton<IApplicationConfiguration>(applicationConfiguration);
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddSingleton<IApplicationSeeder, ApplicationDBContextSeeder>();
builder.Services.AddSingleton<IJWTTokenService,JWTTokenService>();

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(applicationConfiguration.IssuerSigningKey)),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        SaveSigninToken = false,
        RequireExpirationTime = true,
    };
    options.Events = new JwtBearerEvents
    {
        // Add user to context on successful token validation
        OnTokenValidated = res =>
        {
            HttpResponseHelpers.AddUserToContext(res.HttpContext);
            return Task.CompletedTask;
        },
        // Handle authentication failures
        OnAuthenticationFailed = err =>
        {
            Console.WriteLine("ERROR validating app");
            Console.WriteLine(err.Exception.Message);
            if (err.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                HttpResponseHelpers.SendTokenExpiredResponse(err.HttpContext);

            }
            return Task.CompletedTask;
        },
        // Handle forbidden requests
        OnForbidden = req =>
        {
            HttpResponseHelpers.SendInvalidTokenResponse(req.HttpContext);
            return Task.CompletedTask;
        }
    };
});

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Grepo",
        Version = "v1"
    });
    // Add JWT Authentication to Swagger
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
// configure logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
app.UseAuthentication();
app.UseFastEndpoints();

// Enable Swagger in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Initialize and seed the database
if (applicationConfiguration.CreateDB)
{
    await CreateDB(app);
}

if (applicationConfiguration.SeedDB)
{
    await SeedDB(app);
}

if (applicationConfiguration.DeleteDB)
{
    await DeleteDB(app);
}
// Run the application 
await app.RunAsync();

// Helper methods for database operations

/// <summary>
/// Creates the database if it doesn't exist
/// </summary>
async Task CreateDB(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

/// <summary>
/// Seeds the database with initial data
/// </summary>
async Task SeedDB(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IApplicationSeeder>();
    await seeder.Seed();
}

 /// <summary>
 /// Deletes the database
 /// </summary>
 async Task DeleteDB(WebApplication app)
 {
     using var scope = app.Services.CreateScope();
     var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
     await dbContext.Database.EnsureDeletedAsync();
 }








