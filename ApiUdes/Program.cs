using System.Reflection;
using ApiUdes.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add ApplicationServicesExtensions
builder.Services.AddApplicationServices();
builder.Services.ConfigureCors();

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Conection with MySQL
builder.Services.AddDbContext<ApiUdesContext>(options =>
{
    string conectionStrings = builder.Configuration.GetConnectionString("MysqlConnection");
    options.UseMySql(conectionStrings, ServerVersion.AutoDetect(conectionStrings));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApiUdesContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrio un error durante la migracion !!");
    }
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();



/*  

Dependencias

ApiUdes
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.2 

Domain
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
dotnet add package FluentValidation.AspNetCore --version 11.3.0

Persistence
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2




DBFirst
dotnet ef dbcontext scaffold "server=localhost;user=root;password=admin;database=udes" Pomelo.EntityFrameworkCore.MySql -s .\ApiUdes -p .\Domain --context ApiUdesContext --context-dir Data --output-dir Entities

DB Migrations
dotnet ef migrations add FirstMigration --project .\Persistence\ --startup-project .\ApiUdes\ --output-dir ./Data/Migrations

DB Update
dotnet ef database update --project .\Persistence\ --startup-project .\ApiUdes

*/