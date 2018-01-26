using System.Collections.Generic;
using Payments.Domain.Models;

namespace Payments.Domain
{
    public static class DataBootstrapper
    {
        public static List<Payment> GetPayments()
        {
            return new List<Payment>()
                {
                    new Payment
                    {
                        Id = "4ee3a8d8-ca7b-4290-a52c-dd5b6165ec43",
                        Version = 0,
                        OrganisationId = "743d5b63-8e6f-432e-a8fa-c5d8d2ee5fcb",
                        Attributes = new PaymentAttributes
                        {
                            Amount = "100.21",
                            BeneficiaryParty = new Party
                            {
                                AccountName = "R Lothbrok",
                                AccountNumber = "31926819",
                                AccountNumberCode = "BBAN",
                                AccountType = 0,
                                Address = "1 The Kattegat SE2",
                                BankId = "403000",
                                BankIdCode = "GBDSC",
                                Name = "Ragnar Lothbrok"
                            },
                            ChargesInformation = new ChargesInformation
                            {
                                BearerCode = "SHAR",
                                SenderCharges = new List<Charge>
                                {
                                    new Charge { Amount = "5.00", Currency = "GBP" },
                                    new Charge { Amount = "10.00", Currency = "USD" }
                                },
                                ReceiverChargesAmount = "1.00",
                                ReceiverChargesCurrency = "USD"
                            },
                            Currency = "GBP",
                            DebtorParty = new Party
                            {
                                AccountName = "K Egbert",
                                AccountNumber = "GB29XABC10161234567801",
                                AccountNumberCode = "IBAN",
                                Address = "10 Wessex Crescent Sourcetown NE1",
                                BankId = "203301",
                                BankIdCode = "GBDSC",
                                Name = "King Egbert"
                            },
                            EndToEndReferecence = "For all the things I broke",
                            Fx = new Fx
                            {
                                ContractReference = "FX123",
                                ExchangeRate = "2.00000",
                                OriginalAmount = "200.42",
                                OriginalCurrency = "USD"
                            },
                            NumericReference = "1002001",
                            PaymentId = "123456789012345678",
                            PaymentPurpose = "Paying for goods/services",
                            PaymentSheme = "FPS",
                            PaymentType = "Credit",
                            ProcessingDate = "2017-01-18",
                            Reference = "Payment for the things Ragnar broke",
                            SchemePaymentSubType = "InternetBanking",
                            SchemePaymentType = "ImmediatePayment",
                            SponsorParty = new Party
                            {
                                AccountNumber = "56781234",
                                BankId = "123123",
                                BankIdCode = "GBDSC"
                            }
                        }
                    },
                    new Payment
                    {
                        Id = "216d4da9-e59a-4cc6-8df3-3da6e7580b77",
                        Version = 0,
                        OrganisationId = "743d5b63-8e6f-432e-a8fa-c5d8d2ee5fcb",
                        Attributes = new PaymentAttributes
                        {
                            Amount = "100.21",
                            BeneficiaryParty = new Party
                            {
                                AccountName = "R Lothbrok",
                                AccountNumber = "31926819",
                                AccountNumberCode = "BBAN",
                                AccountType = 0,
                                Address = "1 The Kattegat SE2",
                                BankId = "403000",
                                BankIdCode = "GBDSC",
                                Name = "Ragnar Lothbrok"
                            },
                            ChargesInformation = new ChargesInformation
                            {
                                BearerCode = "SHAR",
                                SenderCharges = new List<Charge>
                                {
                                    new Charge { Amount = "5.00", Currency = "GBP" },
                                    new Charge { Amount = "10.00", Currency = "USD" }
                                },
                                ReceiverChargesAmount = "1.00",
                                ReceiverChargesCurrency = "USD"
                            },
                            Currency = "GBP",
                            DebtorParty = new Party
                            {
                                AccountName = "K Egbert",
                                AccountNumber = "GB29XABC10161234567801",
                                AccountNumberCode = "IBAN",
                                Address = "10 Wessex Crescent Sourcetown NE1",
                                BankId = "203301",
                                BankIdCode = "GBDSC",
                                Name = "King Egbert"
                            },
                            EndToEndReferecence = "For all the things I broke",
                            Fx = new Fx
                            {
                                ContractReference = "FX123",
                                ExchangeRate = "2.00000",
                                OriginalAmount = "200.42",
                                OriginalCurrency = "USD"
                            },
                            NumericReference = "1002001",
                            PaymentId = "123456789012345678",
                            PaymentPurpose = "Paying for goods/services",
                            PaymentSheme = "FPS",
                            PaymentType = "Credit",
                            ProcessingDate = "2017-01-18",
                            Reference = "Payment for the things Ragnar broke",
                            SchemePaymentSubType = "InternetBanking",
                            SchemePaymentType = "ImmediatePayment",
                            SponsorParty = new Party
                            {
                                AccountNumber = "56781234",
                                BankId = "123123",
                                BankIdCode = "GBDSC"
                            }
                        }
                    }
                };
        }
    }
}
