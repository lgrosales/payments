namespace Payments.Domain.Models
{
    public class PaymentAttributes
    {
        public string Amount { get; set; }
        public Party BeneficiaryParty { get; set; }
        public ChargesInformation ChargesInformation { get; set; }
        public string Currency { get; set; }
        public Party DebtorParty { get; set; }
        public string EndToEndReferecence { get; set; }
        public Fx Fx { get; set; }
        public string NumericReference { get; set; }
        public string PaymentId { get; set; }
        public string PaymentPurpose { get; set; }
        public string PaymentSheme { get; set; }
        public string PaymentType { get; set; }
        public string ProcessingDate { get; set; }
        public string Reference { get; set; }
        public string SchemePaymentSubType { get; set; }
        public string SchemePaymentType { get; set; }
        public Party SponsorParty { get; set; }
    }
}