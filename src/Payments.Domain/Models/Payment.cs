namespace Payments.Domain.Models
{
    public class Payment
    {
        public Payment()
        {
            Type = "Payment";
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public int Version { get; set; }
        public string OrganisationId { get; set; }
        public PaymentAttributes Attributes {get; set; }
    }
}