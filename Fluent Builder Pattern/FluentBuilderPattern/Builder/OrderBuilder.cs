using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class OrderBuilder
{
    private readonly List<OrderItem> _items = [];
    private Customer _customer;
    private string _orderId;
    private PaymentDetails _payment;
    private Address _shippingAddress;


    public OrderBuilder WithOrderId(string orderId)
    {
        _orderId = orderId;
        return this;
    }

    public OrderBuilder WithOrderItem(Action<OrderItemBuilder> orderItemBuilderAction)
    {
        var orderItemBuilder = new OrderItemBuilder();
        orderItemBuilderAction(orderItemBuilder);
        var orderItem = orderItemBuilder.Build();
        _items.Add(orderItem);
        return this;
    }

    public OrderBuilder ShippedTo(Action<ShippingAddressBuilder> addressBuilderAction)
    {
        var addressBuilder = new ShippingAddressBuilder();
        addressBuilderAction(addressBuilder);
        _shippingAddress = addressBuilder.Build();
        return this;
    }

    public OrderBuilder PaidBy(Action<OrderPayerBuilder> paymentBuilderAction)
    {
        var paymentBuilder = new OrderPayerBuilder();
        paymentBuilderAction(paymentBuilder);
        _payment = paymentBuilder.Build();
        return this;
    }

    public OrderBuilder For(Func<GuidedCustomerBuilder, Customer> guidedCustomerBuilderFunc)
    {
        var guidedActorBuilder = new GuidedCustomerBuilder();
        _customer = guidedCustomerBuilderFunc(guidedActorBuilder);
        return this;
    }

    public Order Build()
    {
        return new Order
        {
            OrderId = _orderId,
            Items = _items,
            ShippingAddress = _shippingAddress,
            Payment = _payment,
            Customer = _customer
        };
    }
}