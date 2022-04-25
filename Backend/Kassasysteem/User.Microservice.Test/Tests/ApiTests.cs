using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using User.Microservice.Data;
using User.Microservice.Test.Stubs;
using Xunit;
using FluentAssertions;
using System.Net;
using User.Microservice.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace User.Microservice.Test
{
    public class ApiTests : WebApplicationFactory<Program>
    {
        UserDALStub stub = new UserDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IUserDAL, UserDALStub>();
            });

            return base.CreateHost(builder);
        }

        [Fact]
        public async void DefaultRoute_ReturnsHelloWorldSucces()
        {
            // Arrange
            var webAppFactory = new ApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("");

            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async void GetUsers_Passed()
        {
            // Arrange
            var webAppFactory = new ApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            // Act
            var response = await httpClient.GetAsync("/user/get/all");

            // Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async void GetCertainUser_Passed()
        {
            // Arrange
            var webAppFactory = new ApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            // Act
            var response = await httpClient.GetAsync("/user/get/44");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void UpdateCertainUser_Passed()
        {
            // Arrange
            UserModel userModel = new UserModel();
            userModel.userName = "mark";
            userModel.userPin = "11";
            var webAppFactory = new ApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = JsonConvert.SerializeObject(userModel);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PutAsync("/user/update/44", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void AddCertainUser_Passed()
        {
            // Arrange
            UserModel userModel = new UserModel();
            userModel.userName = "mark";
            userModel.userPin = "11";
            var webAppFactory = new ApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = JsonConvert.SerializeObject(userModel);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync("/user/add", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void DeleteCertainUser_Passed()
        {
            // Arrange
            UserModel userModel = new UserModel();
            userModel.userName = "mark";
            userModel.userPin = "11";
            var webAppFactory = new ApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = JsonConvert.SerializeObject(userModel);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync("/user/delete/11", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}