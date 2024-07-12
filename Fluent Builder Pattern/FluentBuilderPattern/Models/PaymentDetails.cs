namespace FluentBuilderPattern.Models;

public class PaymentDetails
{
    public string PaymentMethod { get; set; }
    public decimal TotalPaid { get; set; }
    public DateTime PaymentDate { get; set; }
}