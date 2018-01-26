namespace Payments.Domain.Models
{
    public class Payment
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string OrganisationId { get; set; }
        public PaymentAttributes Attributes {get; set; }
    }
}