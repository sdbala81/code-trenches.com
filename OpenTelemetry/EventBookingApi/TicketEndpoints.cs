using Microsoft.EntityFrameworkCore;

namespace EventBookingApi;

public static class TicketEndpoints
{
    public static void MapTicketEndpoints(this WebApplication app)
    {
        app.MapGet("/tickets", async (BookingContext db) =>
            await db.Tickets.ToListAsync());

        app.MapGet("/tickets/{id:int}", async (int id, BookingContext db) =>
            await db.Tickets.FindAsync(id)
                is Ticket ticket
                ? Results.Ok(ticket)
                : Results.NotFound());

        app.MapPost("/tickets", async (Ticket ticket, BookingContext db) =>
        {
            db.Tickets.Add(ticket);
            await db.SaveChangesAsync();
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

            return Results.NoContent();
        });

        app.MapDelete("/tickets/{id:int}", async (int id, BookingContext db) =>
        {
            var ticket = await db.Tickets.FindAsync(id);
            if (ticket is null) return Results.NotFound();

            db.Tickets.Remove(ticket);
            await db.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}