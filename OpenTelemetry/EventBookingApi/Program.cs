using EventBookingApi;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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
    .ConfigureResource(resource => resource.AddService("EventBookingApi"))
    .WithMetrics(metrics =>
    {
        metrics
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddMeter("EventBookingApi")
            .AddOtlpExporter();
    })
    .WithTracing(tracing =>
    {
        tracing
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddEntityFrameworkCoreInstrumentation()
            .AddOtlpExporter();
    });

// add logging
builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapTicketEndpoints();


app.Run();