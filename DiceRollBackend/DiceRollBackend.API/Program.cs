using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Application.Interfaces.Repositories;
using DiceRollBackend.Application.Interfaces.Services;
using DiceRollBackend.Application.Mappings;
using DiceRollBackend.Application.Services;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Domain.Interfaces.Common;
using DiceRollBackend.Persistence.Configuration;
using DiceRollBackend.Persistence.Repositories;
using DiceRollBackend.Persistence.UnitOfWork;
using DiceRollBackend.Persistence.Utils.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Repositories
builder.Services.AddScoped<IRoomRepository<Room>, RoomRepository<Room>>();
builder.Services.AddScoped<IUserRepository<User>, UserRepository<User>>();

//Application services
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();

//Common services
builder.Services.AddScoped<IRoomCodeGenerator, RoomCodeGenerator>();

//Mappings
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;
}, AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();