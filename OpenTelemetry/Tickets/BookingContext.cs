using Microsoft.EntityFrameworkCore;

namespace Tickets;

public class BookingContext(DbContextOptions<BookingContext> options) : DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; }
}