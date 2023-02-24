using Microsoft.OpenApi.Models;
using POC2.Application;
using POC2.Application.Common;
using POC2.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.Configure<ApplicationConstants>(configuration.GetSection("ApplicationConstants"));

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Logs Api");
});

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
