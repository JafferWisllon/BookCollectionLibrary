using BookCollectionLibrary.API.Business;
using BookCollectionLibrary.API.Business.Implementations;
using BookCollectionLibrary.API.Model.Context;
using BookCollectionLibrary.API.Repository;
using BookCollectionLibrary.API.Repository.Implementations;
using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(9, 2, 0));

builder.Services.AddDbContext<MySQLContext>(options =>
{
    options.UseMySql(connection, serverVersion);
});

if (builder.Environment.IsDevelopment())
{
    MigrationDatabase(connection);
}

builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void MigrationDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
