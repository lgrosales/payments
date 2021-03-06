using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Payments.Domain.Models;
using Xunit;

namespace Payments.Tests.Integation
{
    public class PaymentsApiShould
    {
        private readonly HttpClient _client;
        private const string ApiBaseUrl = "/api/payments";

        public PaymentsApiShould()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<TestsStartup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task GetAllPayments()
        {
            await CreatePayment();
            await CreatePayment();

            var response = await _client.GetAsync(ApiBaseUrl);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var payments = JsonConvert.DeserializeObject<List<Payment>>(responseString);

            Assert.Equal(2, payments.Count);
        }

        [Fact]
        public async Task GetPaymentById()
        {
            var paymentId = await CreatePayment();

            var response = await _client.GetAsync($"{ApiBaseUrl}/{paymentId}");
            response.EnsureSuccessStatusCode();
            
            var payment = await DeserializePayment(response.Content);

            Assert.Equal(paymentId, payment.Id);
        }

        [Fact]
        public async Task AddPayment()
        {
            var paymentId = Guid.NewGuid().ToString();

            var payment = new Payment
            {
                Id = paymentId
            };

            var httpContent = SerializePayment(payment);

            var responsePost = await _client.PostAsync(ApiBaseUrl, httpContent);
            responsePost.EnsureSuccessStatusCode();

            var responseGet = await _client.GetAsync($"{ApiBaseUrl}/{paymentId}");
            responseGet.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdatePayment()
        {
            var paymentId = Guid.NewGuid().ToString();

            var newPayment = new Payment
            {
                Id = paymentId,
                Version = 0
            };

            var httpContentNewPayment = SerializePayment(newPayment);

            // Create
            var responsePost = await _client.PostAsync(ApiBaseUrl, httpContentNewPayment);
            responsePost.EnsureSuccessStatusCode();

            // Get
            var responseGet1 = await _client.GetAsync($"{ApiBaseUrl}/{paymentId}");
            responseGet1.EnsureSuccessStatusCode();
            var payment = await DeserializePayment(responseGet1.Content);

            // Update
            payment.Version = 1;
            var httpContentUpdatedPayment = SerializePayment(payment);
            var responsePut = await _client.PutAsync($"{ApiBaseUrl}/{paymentId}", httpContentUpdatedPayment);
            responsePut.EnsureSuccessStatusCode();

            // Check update
            var responseGet2 = await _client.GetAsync($"{ApiBaseUrl}/{paymentId}");
            responseGet2.EnsureSuccessStatusCode();
            var paymentUpdated = await DeserializePayment(responseGet2.Content);

            Assert.Equal(1, paymentUpdated.Version);
        }

        [Fact]
        public async Task DeletePayment()
        {
            var paymentId = await CreatePayment();

            var responseGet1 = await _client.GetAsync($"{ApiBaseUrl}/{paymentId}");
            responseGet1.EnsureSuccessStatusCode();

            var responseDelete = await _client.DeleteAsync($"{ApiBaseUrl}/{paymentId}");
            responseDelete.EnsureSuccessStatusCode();

            var responseGet2 = await _client.GetAsync($"{ApiBaseUrl}/{paymentId}");

            Assert.Equal(HttpStatusCode.NotFound, responseGet2.StatusCode);
        }

        private static HttpContent SerializePayment(Payment payment)
        {
            var stringPayload = JsonConvert.SerializeObject(payment);

            return new StringContent(stringPayload, Encoding.UTF8, "application/json");
        }

        private static async Task<Payment> DeserializePayment(HttpContent httpContent)
        {
            var responseString = await httpContent.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Payment>(responseString);
        }

        private async Task<string> CreatePayment()
        {
            var paymentId = Guid.NewGuid().ToString();

            var payment = new Payment
            {
                Id = paymentId
            };

            var httpContent = SerializePayment(payment);

            await _client.PostAsync(ApiBaseUrl, httpContent);

            return paymentId;
        }
    }
}