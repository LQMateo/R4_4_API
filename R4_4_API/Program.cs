using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using R4_4_API.Models.DataManager;
using R4_4_API.Models.EntityFramework;
using R4_4_API.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddDbContext<LequmaContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("Td4Context")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataRepository<Utilisateur>, UtilisateurManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
