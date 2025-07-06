using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Leer connection string
var connectionString = builder.Configuration.GetConnectionString("BDCore");

// ================================
// Repositorios
// ================================
builder.Services.AddScoped<IProductoRepository>(provider => new ProductoRepository(connectionString));
builder.Services.AddScoped<IServiciosRepository>(provider => new ServiciosRepository(connectionString));
builder.Services.AddScoped<IUsuarioRepository>(provider => new UsuarioRepository(connectionString));
builder.Services.AddScoped<IClienteRepository>(provider => new ClienteRepository(connectionString));
builder.Services.AddScoped<IFacturasRepository>(provider => new FacturasRepository(connectionString));
builder.Services.AddScoped<ICotizacionesRepository>(provider => new CotizacionesRepository(connectionString));
builder.Services.AddScoped<ICuentasPorCobrarRepository>(provider => new CuentasPorCobrarRepository(connectionString));
builder.Services.AddScoped<ILogsRepository>(provider => new LogsRepository(connectionString));
builder.Services.AddScoped<IInventarioMovimientoRepository>(provider => new InventarioMovimientoRepository(connectionString));
builder.Services.AddScoped<IPerfilesRepository>(provider => new PerfilesRepository(connectionString));

// ================================
// Services
// ================================
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<ICotizacionService, CotizacionService>();
builder.Services.AddScoped<ICuentasPorCobrarService, CuentasPorCobrarService>();
builder.Services.AddScoped<ILogsService, LogsService>();
builder.Services.AddScoped<IInventarioMovimientoService, InventarioMovimientoService>();

// ================================
// Controllers, Swagger y pipeline
// ================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
