namespace Payments.Domain.Models
{
    public class Party
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNumberCode { get; set; }
        public int AccountType { get; set; }
        public string Address { get; set; }
        public string BankId { get; set; }
        public string BankIdCode { get; set; }
        public string Name { get; set; }
    }
}