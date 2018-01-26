using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Payments.API.Controllers;
using Payments.Domain.Models;
using Xunit;
using Payments.Domain.Repositories;

namespace Payments.Tests.Unit
{
    public class PaymentsControllerTests
    {
        private readonly Mock<IPaymentsRepository> _repositoryMock;
        private readonly PaymentsController _paymentsController;

        public PaymentsControllerTests()
        {
            _repositoryMock = new Mock<IPaymentsRepository>();

            _paymentsController = new PaymentsController(_repositoryMock.Object);
        }

        private static List<Payment> GetTestPayments()
        {
            return new List<Payment>()
            {
                new Payment
                {
                    Id = "id1",
                    Version = 0,
                    OrganisationId = "orgId"
                },
                new Payment
                {
                    Id = "id2",
                    Version = 0,
                    OrganisationId = "orgId2"
                }
            };
        }

        [Fact]
        public void GetAll_WhenPaymentsFound_Returns200AndPaymentList()
        {
            _repositoryMock
                .Setup(r=> r.GetAll())
                .Returns(Task.FromResult(GetTestPayments()));

            var response = _paymentsController.GetAll().Result as ObjectResult;
            
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            var payments = response.Value as List<Payment>;
            Assert.NotNull(payments);
            Assert.Equal(2, payments.Count());
        }

        [Fact]
        public void GetAll_WhenPaymentsNotFound_Returns200AndEmptyList()
        {
            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(Task.FromResult(new List<Payment>()));

            var response = _paymentsController.GetAll().Result as ObjectResult;

            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            var payments = response.Value as List<Payment>;
            Assert.NotNull(payments);
            Assert.Empty(payments);
        }

        [Fact]
        public void GetById_WhenPaymentFound_Returns200AndPayment()
        {
            _repositoryMock
                .Setup(r => r.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(new Payment { Id = "paymentId" }));

            var response = _paymentsController.GetById("paymentId").Result as ObjectResult;

            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            var payment = response.Value as Payment;
            Assert.NotNull(payment);
            Assert.Equal("paymentId", payment.Id);
        }

        [Fact]
        public void GetById_WhenPaymentNotFound_Returns404NotFound()
        {
            _repositoryMock
                .Setup(r => r.Get(It.IsAny<string>()))
                .Returns(Task.FromResult<Payment>(null));

            var response = _paymentsController.GetById("paymentId").Result as NotFoundResult;

            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void Create_WhenPaymentCreated_Returns201Created()
        {
            _repositoryMock
                .Setup(r => r.Add(It.IsAny<Payment>()))
                .Returns(Task.CompletedTask);

            var response = _paymentsController.Create(new Payment()).Result as CreatedAtRouteResult;

            Assert.NotNull(response);
            Assert.Equal(201, response.StatusCode);
        }

        [Fact]
        public void Create_WhenPaymentNotSent_Returns400BadRequest()
        {
            var response = _paymentsController.Create(null).Result as BadRequestResult;

            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public void Update_WhenPaymentUpdated_Returns204NoContent()
        {
            _repositoryMock
                .Setup(r => r.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(new Payment()));

            _repositoryMock
                .Setup(r => r.Update(It.IsAny<Payment>()))
                .Returns(Task.CompletedTask);

            var response = _paymentsController.Update("paymentId", new Payment { Id = "paymentId" }).Result as NoContentResult;

            Assert.NotNull(response);
            Assert.Equal(204, response.StatusCode);
        }

        [Fact]
        public void Update_WhenPaymentNotFound_Returns404NotFound()
        {
            _repositoryMock
                .Setup(r => r.Get(It.IsAny<string>()))
                .Returns(Task.FromResult<Payment>(null));

            var response = _paymentsController.Update("paymentId", new Payment { Id = "paymentId" }).Result as NotFoundResult;

            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void Update_WhenPaymentNotSent_Returns400BadRequest()
        {
            var response = _paymentsController.Update(null, null).Result as BadRequestResult;

            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public void Delete_WhenPaymentNotFound_Returns404NotFound()
        {
            _repositoryMock
                .Setup(r => r.Get(It.IsAny<string>()))
                .Returns(Task.FromResult<Payment>(null));

            var response = _paymentsController.Delete("paymentId").Result as NotFoundResult;

            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void Delete_WhenPaymentDeleted_Returns204NoContent()
        {
            _repositoryMock
                .Setup(r => r.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(new Payment()));

            _repositoryMock
                .Setup(r => r.Delete(It.IsAny<Payment>()))
                .Returns(Task.CompletedTask);

            var response = _paymentsController.Delete("paymentId").Result as NoContentResult;

            Assert.NotNull(response);
            Assert.Equal(204, response.StatusCode);
        }
    }
}