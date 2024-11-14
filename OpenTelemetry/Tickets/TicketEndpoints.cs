using Microsoft.EntityFrameworkCore;

namespace Tickets;

public static class TicketEndpoints
{
    public static void MapTicketEndpoints(this WebApplication app)
    {
        var logger = app.Logger;

        app.MapGet("/tickets", async (BookingContext db) =>
            await db.Tickets.ToListAsync());

        app.MapGet("/tickets/{id:int}", async (int id, BookingContext db) =>
        {
            logger.LogInformation("Fetching ticket {TicketId}", id);

            return await db.Tickets.FindAsync(id)
                is Ticket ticket
                ? Results.Ok(ticket)
                : Results.NotFound();
        });

        app.MapPost("/tickets", async (Ticket ticket, BookingContext db) =>
        {
            var addedTicket = db.Tickets.Add(ticket);

            await db.SaveChangesAsync();

            TicketTelemetryConfig.TickerCounter.Add(
                1,
                new KeyValuePair<string, object?>("ticket", ticket),
                new KeyValuePair<string, object?>("ticket.id", addedTicket.Entity.Id),
                new KeyValuePair<string, object?>("ticket.created.date",
                    addedTicket.Entity.CreatedOnUtc.Date.ToShortDateString()));


            logger.LogInformation("Created ticket {TicketId}", ticket.Id);

            return Results.Created($"/tickets/{ticket.Id}", ticket);
        });

        app.MapPut("/tickets/{id:int}", async (int id, Ticket updatedTicket, BookingContext db) =>
        {
            var ticket = await db.Tickets.FindAsync(id);
            if (ticket is null) return Results.NotFound();

            ticket.EventName = updatedTicket.EventName;
            ticket.BookingDate = updatedTicket.BookingDate;
            ticket.SeatNumber = updatedTicket.SeatNumber;
            ticket.Price = updatedTicket.Price;
            await db.SaveChangesAsync();

            logger.LogInformation("Updated ticket {TicketId}", id);

            return Results.NoContent();
        });

        app.MapDelete("/tickets/{id:int}", async (int id, BookingContext db) =>
        {
            var ticket = await db.Tickets.FindAsync(id);
            if (ticket is null) return Results.NotFound();

            db.Tickets.Remove(ticket);
            await db.SaveChangesAsync();

            logger.LogInformation("Deleted ticket {TicketId}", id);
            return Results.NoContent();
        });
    }
}