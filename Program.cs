using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client; // para el ResponseWriter
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Configura el DbContext normalmente
builder.Services.AddDbContext<BdClientesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

// Agrega HealthChecks y verifica la conexión a la base de datos SQL Server
builder.Services.AddHealthChecks()
    .AddSqlServer(
        builder.Configuration.GetConnectionString("ClienteDB"),
        name: "sqlserver",
        healthQuery: "SELECT 1;", // simple query para comprobar la conexión
        failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
        tags: new[] { "db", "sql" });

// Servicios existentes
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para exponer métricas de prometheus
app.UseHttpMetrics();
// Swagger y middleware usual
app.UseSwagger();

app.UseSwaggerUI();
// app.UseHttpsRedirection();
app.UseAuthorization();

// Mapea el endpoint para HealthChecks con salida en formato JSON legible para Prometheus / Grafana
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// Endpoint para prometheus (exponer /metrics)
app.MapMetrics();

app.MapControllers();

app.Run("http://0.0.0.0:80");
