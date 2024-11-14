using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Tickets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;


// Add services DbContxt here
services.AddDbContext<BookingContext>(options => options.UseInMemoryDatabase("TicketBookingDb"));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// add open telemetry
services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(TicketTelemetryConfig.ApiName))
    .WithMetrics(metrics =>
    {
        metrics
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddMeter(TicketTelemetryConfig.ApiName)
            .AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri("http://tickets.dashboard:18889"); // Metrics endpoint
                options.Protocol = OtlpExportProtocol.HttpProtobuf;
            });
    })
    .WithTracing(tracing =>
    {
        tracing
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddEntityFrameworkCoreInstrumentation(options =>
            {
                options.SetDbStatementForText = true;
                options.SetDbStatementForStoredProcedure = true;
                options.SetDbStatementForText = true;
                options.EnrichWithIDbCommand = (activity, command) =>
                {
                    // Optional: Add custom tags related to the SQL command
                    activity.SetTag("db.command", command.CommandText);
                };
            })
            .AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri("http://tickets.dashboard:18889"); // Metrics endpoint
                options.Protocol = OtlpExportProtocol.HttpProtobuf;
            });
    });

// add logging
builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter(options =>
{
    options.Endpoint = new Uri("http://tickets.dashboard:18889"); // Metrics endpoint
    options.Protocol = OtlpExportProtocol.HttpProtobuf;
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapTicketEndpoints();

app.Run();