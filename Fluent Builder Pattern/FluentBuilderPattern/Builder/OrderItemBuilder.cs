using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class OrderItemBuilder
{
    private string _productName;
    private decimal _unitPrice;
    private int _quantity;

    public OrderItemBuilder WithProductName(string productName)
    {
        _productName = productName;
        return this;
    }

    public OrderItemBuilder WithUnitPrice(decimal unitPrice)
    {
        _unitPrice = unitPrice;
        return this;
    }

    public OrderItemBuilder WithQuantity(int quantity)
    {
        _quantity = quantity;
        return this;
    }

    public OrderItem Build()
    {
        return new OrderItem
        {
            ProductName = _productName,
            UnitPrice = _unitPrice,
            Quantity = _quantity
        };
    }
}
