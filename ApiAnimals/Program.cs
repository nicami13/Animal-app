using System.Reflection;
using ApiAnimals.Extensions;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureRatelimiting();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddAplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnimalsContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MysqlConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
 void ConfigureServices(IServiceCollection services)
    {
        // ... otras configuraciones

        services.AddDbContext<AnimalsContext>(options =>
        {
            string connectionString = builder.Configuration.GetConnectionString("MysqlConex");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        // ... otras configuraciones
    }



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();