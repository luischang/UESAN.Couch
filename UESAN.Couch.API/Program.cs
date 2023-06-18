using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Core.Services;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;
using UESAN.Couch.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var connectionString = _configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<CoachServicesContext>(options => options.UseSqlServer(connectionString));

//Aqui van el contexto en los repositorios y servicios

builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<IUsuariosServices, UsuariosServices>();

builder.Services.AddTransient<IJWTFactory, JWTFactory>();

builder.Services.AddTransient<IPagoRepository, PagoRepository>();
builder.Services.AddTransient<IPagoServices, PagoServices>();

builder.Services.AddTransient<IDetallePagoRepository, DetallePagoRepository>();
builder.Services.AddTransient<IDetallePagoService, DetallePagoService>();

builder.Services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddTransient<ITiposUsuariosService, TiposUsuariosService>();

builder.Services.AddTransient<IEmprendedoresRepository, EmprendedoresRepository>();
builder.Services.AddTransient<IEmprendadoresServices, EmprendadoresServices>();

builder.Services.AddTransient<IServiciosCoachingRepository, ServiciosCoachingRepository>();
builder.Services.AddTransient<IServiciosCoachingService, ServiciosCoachingService>();

builder.Services.AddTransient<ICoachesRepository, CoachesRepository>();
builder.Services.AddTransient<ICoachesService, CoachesService>();

builder.Services.AddTransient<IDetalleCoachServicioRepository, DetalleCoachServicioRepository>();
builder.Services.AddTransient<IDetalleCoachService, DetalleCoachService>();

builder.Services.AddTransient<ITiposUsuariosService, TiposUsuariosService>();
builder.Services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();

builder.Services.AddTransient<ITiposUsuariosService, TiposUsuariosService>();
builder.Services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();

builder.Services.AddTransient<ITipoPlanService, TipoPlanService>();
builder.Services.AddTransient<ITipoPlanRepository, TipoPlanRepository>();


builder.Services.AddDbContext<CoachServicesContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSharedInfrastructure(_configuration);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            //.WithOrigins("aquivatulocalhost_o_dominio_url")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Agregar el esquema de seguridad JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en el formato 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    // Agregar el requisito de seguridad JWT a nivel global
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
