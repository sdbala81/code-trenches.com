// See https://aka.ms/new-console-template for more information

using FluentBuilderPattern.Builder;

Console.WriteLine("Fluent Builder Pattern");

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
    .ShippedTo(address => address
        .WithNo("123")
        .WithStreetName("Main Street")
        .WithCity("Metropolis")
        .WithCounty("Central")
        .WithCountry("USA"))
    .PaidBy(payment => payment
        .By("Credit Card")
        .OfOrderTotal(1540.00m)
        .PaidOn(DateTime.UtcNow))
    .For(a => CustomerBuilder.Create()
        .WithFirstName("John")
        .WithLastName("Doe")
        .BornIn(1981)
        .Build())
    .Build();

// Displaying the order details
Console.WriteLine($"Order ID: {order.OrderId}");

Console.WriteLine("Customer:");
Console.WriteLine($"- {order.Customer.FirstName} {order.Customer.LastName}");
Console.WriteLine($"- {order.Customer.BirthYear}");

Console.WriteLine("Items:");

foreach (var item in order.Items) Console.WriteLine($"- {item.ProductName}: {item.Quantity} x {item.UnitPrice:C}");

Console.WriteLine(
    $"Shipping Address: {order.ShippingAddress.No}, {order.ShippingAddress.StreetName}, {order.ShippingAddress.City}, {order.ShippingAddress.County}, {order.ShippingAddress.Country}");

Console.WriteLine(
    $"Payment Method: {order.Payment.PaymentMethod}, Total Paid: {order.Payment.TotalPaid:C}, Payment Date: {order.Payment.PaymentDate}");