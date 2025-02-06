using BookCollectionLibrary.API.Business;
using BookCollectionLibrary.API.Business.Implementations;
using BookCollectionLibrary.API.Model.Context;
using BookCollectionLibrary.API.Repository;
using BookCollectionLibrary.API.Repository.Implementations;
using Microsoft.EntityFrameworkCore;

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
