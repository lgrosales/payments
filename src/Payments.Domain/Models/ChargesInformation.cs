using System.Collections.Generic;

namespace Payments.Domain.Models
{
    public class ChargesInformation
    {
        public string Id { get; set; }
        public string BearerCode { get; set; }
        public IEnumerable<Charge> SenderCharges { get; set; }
        public string ReceiverChargesAmount { get; set; }
        public string ReceiverChargesCurrency { get; set; }
    }
}