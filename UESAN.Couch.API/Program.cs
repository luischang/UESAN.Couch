using Microsoft.EntityFrameworkCore;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Core.Services;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var connectionString = _configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<CoachServicesContext>(options => options.UseSqlServer(connectionString));

//Aqui van el contexto en los repositorios y servicios
builder.Services.AddTransient<IServiciosCoachingRepository, ServiciosCoachingRepository>();
builder.Services.AddTransient<IServiciosCoachingService, ServiciosCoachingService>();
<<<<<<< HEAD
builder.Services.AddTransient<ITiposUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<ITiposUsuariosService, TiposUsuariosService>();
builder.Services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddTransient<ITipoPlanService, TipoPlanService>();
builder.Services.AddTransient<ITipoPlanRepository, TipoPlanRepository>();
builder.Services.AddTransient<IHorarioService, HorarioService>();
builder.Services.AddTransient<IHorarioRepository, HorarioRepository>();

=======
builder.Services.AddDbContext<CoachServicesContext>(options => options.UseSqlServer(connectionString));
>>>>>>> da7709f35145438f10d454a86853b30be71933d0

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
