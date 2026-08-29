using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Tests1.Helpers;
using Tests1.DTO;
using Tests1.Interfaces;
using Tests1.Preconditions;
using Tests1.Interfaces.DapperTestsInterfaces;
using FluentAssertions;

namespace Tests1.Tests
{
    public class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test002GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(15);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test003GetUserByNameAndSurname()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users.firstName.Should().Be("Мария");
            users.lastName.Should().Be("Павлова");
        }

        [Test]
        public async Task Test004GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(1);
            address.Should().NotBeNull();
        }

        [Test]
        public async Task Test005GetAllCategoriesFromDbAndCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategories();
            categories.Should().HaveCount(6);
        }

        [Test]
        public async Task Test006GetProductById()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var product = await repo.GetProductById(1);
            product.id.Should().Be(1);
            product.name.Should().Be("iPhone 15");
            product.description.Should().Be("Смартфон Apple");
            product.price.Should().Be(79990);
            product.stock.Should().Be(15);
            product.categoryId.Should().Be(1);
        }

        //[Test] //генерация базы - раскомментить, а потом запустить тест разово
        //public async Task InitialiseTest()
        //{
        //    var connectionString = "Data Source=marketplace.db";
        //    await using var connection = new SqliteConnection(connectionString);
        //    await connection.OpenAsync();
        //    await DatabaseInitializer.InitializeAsync(connection);
        //}
    }
}
