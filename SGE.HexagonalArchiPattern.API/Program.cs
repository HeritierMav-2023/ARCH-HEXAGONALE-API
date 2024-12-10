using Microsoft.OpenApi.Models;
using SGE.HexagonalArchiPattern.Persistence;
using SGE.HexagonalArchiPattern.Persistence.Database;
using SGE.HexagonalArchiPattern.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceLayer(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SGE.HexagonalArchiPattern.API", Version = "v1" });
    }
    );

var app = builder.Build();

//using var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<SgeHexagonaleDbContext>();
//dbContext.AddSeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SGE.HexagonalArchiPattern.API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
