namespace FluentBuilderPattern.Models;

public class Order
{
    public string OrderId { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public Address ShippingAddress { get; set; }
    public PaymentDetails Payment { get; set; }
}