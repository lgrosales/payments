using Xunit;

namespace Payments.Tests.Unit
{
    public class PaymentsControllerTests
    {
        [Fact]
        public void GetById_WhenPaymentNotFound_Returns404_()
        {

        }

        [Fact]
        public void Create_WhenPaymentCreated_Returns201()
        {
        }

        [Fact]
        public void Create_WhenPaymentCreated_ReturnsHeaderWithUrlToPayment()
        {
        }

        [Fact]
        public void Create_WhenContentTypeNotSet_Returns415()
        {
        }

        [Fact]
        public void Create_WhenBodyNotSet_Returns400()
        {
        }
    }
}