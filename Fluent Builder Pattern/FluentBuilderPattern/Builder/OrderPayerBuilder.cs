using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class OrderPayerBuilder
{
    private string _paymentMethod;
    private decimal _totalPaid;
    private DateTime _paymentDate;

    public OrderPayerBuilder By(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderPayerBuilder OfOrderTotal(decimal totalPaid)
    {
        _totalPaid = totalPaid;
        return this;
    }

    public OrderPayerBuilder PaidOn(DateTime paymentDate)
    {
        _paymentDate = paymentDate;
        return this;
    }

    public PaymentDetails Build()
    {
        return new PaymentDetails
        {
            PaymentMethod = _paymentMethod,
            TotalPaid = _totalPaid,
            PaymentDate = _paymentDate
        };
    }
}
