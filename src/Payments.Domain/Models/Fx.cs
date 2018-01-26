namespace Payments.Domain.Models
{
    public class Fx
    {
        public string ContractReference { get; set; }
        public string ExchangeRate { get; set; }
        public string OriginalAmount { get; set; }
        public string OriginalCurrency { get; set; }
    }
}