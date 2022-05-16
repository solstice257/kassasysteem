using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Order.Microservice.Data;
using Order.Microservice.Model;
using Order.Microservice.Test.Stubs;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Order.Microservice.Test
{
    public class OrderApiTests : WebApplicationFactory<OrderProgram>
    {

        OrderDALStub stub = new OrderDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IOrderDAL, OrderDALStub>();
            });

            return base.CreateHost(builder);
        }

        [Fact]
        public async void DefaultRoute_ReturnsHelloWorldSucces()
        {
            // Arrange
            var webAppFactory = new OrderApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void GetOrders_Passed()
        {
            // Arrange
            var webAppFactory = new OrderApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            // Act
            var response = await httpClient.GetAsync("/order/get/all");

            // Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async void AddOrders_Passed()
        {
            // Arrange
            List<OrderModel> ordermodels = new List<OrderModel>();

            OrderModel orderModel = new OrderModel();
            orderModel.orderID = 1;
            orderModel.orderName = "Bier";
            orderModel.price = 3;
            orderModel.alcoholic = true;

            ordermodels.Add(orderModel);

            var webAppFactory = new OrderApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = JsonConvert.SerializeObject(ordermodels);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync("/order/add", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async void DeleteOrders_Passed()
        {
            {
                // Arrange
                var webAppFactory = new OrderApiTests();
                HttpClient httpClient = webAppFactory.CreateClient();
                stub.testValue = true;

                // Act
                var response = await httpClient.DeleteAsync("/order/delete/1");

                // Assert
                response.EnsureSuccessStatusCode();
            }
        }
    }
}