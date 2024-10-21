namespace EventBookingApi;

public class Ticket
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public DateTime BookingDate { get; set; }
    public string SeatNumber { get; set; }
    public decimal Price { get; set; }
}