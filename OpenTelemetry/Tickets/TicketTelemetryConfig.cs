using System.Diagnostics.Metrics;

namespace Tickets;

public static class TicketTelemetryConfig
{
    public const string ApiName = "Tickets";

    public static readonly Meter Meter = new(ApiName);

    public static Counter<int> TickerCounter = Meter.CreateCounter<int>("ticket.count");
}