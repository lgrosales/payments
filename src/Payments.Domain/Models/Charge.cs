namespace Payments.Domain.Models
{
    public class Charge
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
}