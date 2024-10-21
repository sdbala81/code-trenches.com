using Microsoft.EntityFrameworkCore;

namespace EventBookingApi;

public class BookingContext(DbContextOptions<BookingContext> options) : DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; }
}