using GenReport;
using GenReport.Infrastructure.Configuration;
using GenReport.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

var config  = app.Services.GetService<IApplicationConfiguration>() ?? throw new ArgumentNullException(nameof(IApplicationConfiguration));
if (config.DeleteDB)
{
    await Startup.DeleteDB(app);
}
if (config.CreateDB)
{
   await Startup.CreateDB(app);
}
if(config.SeedDB)
{
    await Startup.SeedDB(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/exception");
}

app.UseHttpsRedirection();
app.UseRateLimiter();


app.Run();


