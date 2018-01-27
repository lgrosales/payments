using Newtonsoft.Json;

namespace Payments.Domain.Models
{
    public class Fx
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string ContractReference { get; set; }
        public string ExchangeRate { get; set; }
        public string OriginalAmount { get; set; }
        public string OriginalCurrency { get; set; }
    }
}