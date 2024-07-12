using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class OrderPaymentBuilder
{
    private string _paymentMethod;
    private decimal _totalPaid;
    private DateTime _paymentDate;

    public OrderPaymentBuilder WithPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderPaymentBuilder WithTotalPaid(decimal totalPaid)
    {
        _totalPaid = totalPaid;
        return this;
    }

    public OrderPaymentBuilder WithPaymentDate(DateTime paymentDate)
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
