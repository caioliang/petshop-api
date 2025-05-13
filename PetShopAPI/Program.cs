using Microsoft.EntityFrameworkCore;
using OracleOfficial = Oracle.EntityFrameworkCore.OracleDbContextOptionsExtensions;
using PetShop.Application;
using PetShop.Domain;
using PetShop.Domain.Estruturas;
using PetShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PetShopDbContext>(options =>
    OracleOfficial.UseOracle(options, connectionString)
);

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<AnimalService>();

var app = builder.Build();

// cria o banco/tabelas se não existirem
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
