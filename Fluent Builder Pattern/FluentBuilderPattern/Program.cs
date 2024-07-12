// See https://aka.ms/new-console-template for more information

using FluentBuilderPattern;
using FluentBuilderPattern.Builder;

Console.WriteLine("Hello, World!");


var order = new OrderBuilder()
    .WithOrderId("ORD12345")
    .WithOrderItem(item => item
        .WithProductName("Laptop")
        .WithUnitPrice(1500.00m)
        .WithQuantity(1))
    .WithOrderItem(item => item
        .WithProductName("Mouse")
        .WithUnitPrice(20.00m)
        .WithQuantity(2))
    .WithShippingAddress(address => address
        .WithNo("123")
        .WithStreetName("Main Street")
        .WithCity("Metropolis")
        .WithCounty("Central")
        .WithCountry("USA"))
    .WithPaymentDetails(payment => payment
        .WithPaymentMethod("Credit Card")
        .WithTotalPaid(1540.00m)
        .WithPaymentDate(DateTime.UtcNow))
    .Build();

// Displaying the order details
Console.WriteLine($"Order ID: {order.OrderId}");
Console.WriteLine("Items:");
foreach (var item in order.Items)
{
    Console.WriteLine($"- {item.ProductName}: {item.Quantity} x {item.UnitPrice:C}");
}
Console.WriteLine($"Shipping Address: {order.ShippingAddress.No}, {order.ShippingAddress.StreetName}, {order.ShippingAddress.City}, {order.ShippingAddress.County}, {order.ShippingAddress.Country}");
Console.WriteLine($"Payment Method: {order.Payment.PaymentMethod}, Total Paid: {order.Payment.TotalPaid:C}, Payment Date: {order.Payment.PaymentDate}");
