﻿using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class OrderBuilder
{
    private string _orderId;
    private readonly List<OrderItem> _items = [];
    private Address _shippingAddress;
    private PaymentDetails _payment;

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

    public OrderBuilder WithShippingAddress(Action<ShippingAddressBuilder> addressBuilderAction)
    {
        var addressBuilder = new ShippingAddressBuilder();
        addressBuilderAction(addressBuilder);
        _shippingAddress = addressBuilder.Build();
        return this;
    }

    public OrderBuilder WithPaymentDetails(Action<OrderPaymentBuilder> paymentBuilderAction)
    {
        var paymentBuilder = new OrderPaymentBuilder();
        paymentBuilderAction(paymentBuilder);
        _payment = paymentBuilder.Build();
        return this;
    }

    public Order Build()
    {
        return new Order
        {
            OrderId = _orderId,
            Items = _items,
            ShippingAddress = _shippingAddress,
            Payment = _payment
        };
    }
}