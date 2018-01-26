using Xunit;

namespace Payments.Tests.Unit
{
    public class PaymentsControllerTests
    {
        [Fact]
        public void Get_WhenPaymentsFound_ReturnsPayments()
        {
        }

        [Fact]
        public void Get_WhenPaymentsNotFound_ReturnsEmptyResponse()
        {

        }

        [Fact]
        public void GetById_WhenPaymentFound_ReturnsPayment()
        {
        }

        [Fact]
        public void GetById_WhenPaymentNotFound_Returns404NotFound()
        {

        }

        [Fact]
        public void Create_WhenPaymentCreated_Returns201Created()
        {
        }

        [Fact]
        public void Create_WhenPaymentCreated_ReturnsHeaderWithUrlToPayment()
        {
        }

        [Fact]
        public void Create_WhenContentTypeNotSet_Returns415UnsupportedMediaType()
        {
        }

        [Fact]
        public void Create_WhenBodyNotSet_Returns400BadRequest()
        {
        }

        [Fact]
        public void Update_WhenPaymentUpdated_Returns204NoContent()
        {
        }

        [Fact]
        public void Update_WhenPaymentNotFound_Returns404NotFound()
        {
        }

        [Fact]
        public void Update_WhenBodyOrIdNotSet_Returns400BadRequest()
        {
        }

        [Fact]
        public void Update_WhenContentTypeNotSet_Returns415UnsupportedMediaType()
        {
        }

        [Fact]
        public void Delete_WhenPaymentNotFound_Returns404NotFound()
        {
        }

        [Fact]
        public void Delete_WhenPaymentDeleted_Returns204NoContent()
        {
        }
    }
}