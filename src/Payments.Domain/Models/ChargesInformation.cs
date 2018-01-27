using System.Collections.Generic;
using Newtonsoft.Json;

namespace Payments.Domain.Models
{
    public class ChargesInformation
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string BearerCode { get; set; }
        public IEnumerable<Charge> SenderCharges { get; set; }
        public string ReceiverChargesAmount { get; set; }
        public string ReceiverChargesCurrency { get; set; }
    }
}