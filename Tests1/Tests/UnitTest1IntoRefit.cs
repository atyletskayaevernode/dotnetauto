using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Tests1.DTO;
using Tests1.Interfaces;

namespace Tests1.Tests
{
    public class UnitTest1IntoRefit
    {
        private IUserApi api;
        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://reqres.in/api");
                });
            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IUserApi>();
        }

        [Test] //тест на проверку успешного статус кода на гет запрос
        public async Task Test1()
        {
            var response = await api.GetUserStatusAsync(2);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test] //тест на проверку полей в респонсе на гет запрос - согласно UserResponseDTO
        public async Task Test2()
        {
            UserResponseDTO userResponse = await api.GetUserAsync(2);
            UserDataDTO user = userResponse.Data;
        }

        [Test] //тест на создание юзера (по CreateUserRequestDTO) и наличие полей в респонсе (по CreateUserResponseDTO)
        public async Task Test3()
        {
            var createNewUserRequest = new CreateUserRequestDTO
            {
                Name = "Justus",
                Job = "Cheerful milkman"
            };
            CreateUserResponseDTO createdUser = await api.CreateUserAsync(createNewUserRequest);
        }

        [Test] //тест на успешный статус код при пут запросе
        public async Task Test4()
        {
            var updateUserRequest = new CreateUserRequestDTO
            {
                Name = "Justus",
                Job = "Internet celebrity"
            };
            var response = await api.UpdateUserAsync(2, updateUserRequest);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test] // тест на успешный статус код при delete запросе
        public async Task Test5()
        {
            var response = await api.DeleteUserAsync(2);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
