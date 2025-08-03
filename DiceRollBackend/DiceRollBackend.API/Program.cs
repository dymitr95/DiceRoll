using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Application.Interfaces.Repositories;
using DiceRollBackend.Application.Interfaces.Services;
using DiceRollBackend.Application.Services;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Persistence.Configuration;
using DiceRollBackend.Persistence.Repositories;
using DiceRollBackend.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Repositories
builder.Services.AddScoped<IRoomRepository<Room>, RoomRepository<Room>>();

//Services
builder.Services.AddScoped<IRoomService, RoomService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();