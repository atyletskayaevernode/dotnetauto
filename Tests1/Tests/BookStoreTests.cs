using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.BookStoreDTO;
using Tests1.Interfaces.BookStoreInterfaces;

namespace Tests1.Tests
{
    public class BookStoreTests
    {
        private IBookStoreApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookStoreApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookStoreApi>();
        }

        //[Test] // больше не будет работать, юзер уже создан
        //public async Task CreateNewUser()
        //{
        //    var credentials = new UserCreateRequestDTO("GabaGama", "StrongPass123!");
        //    var result = await api.CreateUserAsync(credentials); //"userID": "718e8c1a-8cc9-4130-8a6f-8a1dda323415","username": "GabaGama","books": []
        //    result.Should().NotBeNull();
        //}

        [Test]
        public async Task GetUserToken()
        {
            var credentials = new UserCreateRequestDTO("GabaGama", "StrongPass123!");
            var result = await api.GenerateTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }
    }
}
