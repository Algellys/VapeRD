using TiendaVapes.Integracion.Services;
using TiendaVapes.Integracion.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ?? Registro de servicios (Inyección de dependencias)

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IServiciosService, ServiciosService>();
builder.Services.AddScoped<ICotizacionService, CotizacionService>();
builder.Services.AddScoped<ICuentasPorCobrarService, CuentasPorCobrarService>();
// ?? Agrega aquí InventarioMovimientoService si lo implementas

// Build app
var app = builder.Build();

// Configure middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
