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

        [Test] //2.1 Получить из базы все категории, проверить на количество (смотрите файл с инициализацией)
        public async Task Test005GetAllCategoriesFromDbAndCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategories();
            categories.Should().HaveCount(6);
        }

        [Test] //2.2 Получить из таблицы Products определенный продукт по его id, проверить его поля, что это действительно тот продукт, который мы ожидали
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

        [Test] //2.3 Получить из таблицы Orders конкретный заказ конкретного юзера и проверить, что в нем именно те товары (Items), которые в нем должны быть
        public async Task Test007GetOrderByIdAndCheckItemsInThisOrder()
        {
            var orderRepo = p.Provider.GetService<IOrderRepository>();
            var itemsRepo = p.Provider.GetService<IOrderItemsRepository>();

            var order = await orderRepo.GetOrderByUserId(1, 1);
            order.Should().NotBeNull();

            var items = await itemsRepo.GetOrderItemsByOrderId((int)order.id);
            items.Should().HaveCount(2);

            var productIds = items.Select(item => item.productId).ToList();
            productIds.Should().BeEquivalentTo(new[] { 1L, 15L });
        }

        [Test]
        public async Task AccessoriesBoughtByUsersFromDifferentCitiesAsync()
        {
            var productRepo = p.Provider.GetService<IProductRepository>();
            var itemsRepo = p.Provider.GetService<IOrderItemsRepository>();
            var orderRepo = p.Provider.GetService<IOrderRepository>();
            var addressRepo = p.Provider.GetService<IAddressRepository>();

            var accessoryProductsIds = (await productRepo.GetProductsByCategoryId(6))
                .Select(product => product.id)
                .ToList();

            var orderIds = (await itemsRepo.GetOrderItemsByProductIds(accessoryProductsIds))
                .Select(item => item.orderId)
                .Distinct()
                .ToList();

            var userIds = (await orderRepo.GetOrdersByIds(orderIds))
                .Select(order => order.userId)
                .Distinct()
                .ToList();

            var cities = new List<string>();
            foreach (var userId in userIds)
            {
                var address = await addressRepo.GetAddressByUserId((int)userId);
                cities.Add(address.city);
            }
            cities.Should().Contain(new[] { "Москва", "Екатеринбург" });
        }

        [Test] // тест фейлится, потому что в базе таких покупателей нет
        public async Task TvBuyersAlsoBuyAccessoriesAsync()
        {
            var productRepo = p.Provider.GetService<IProductRepository>();
            var itemsRepo = p.Provider.GetService<IOrderItemsRepository>();
            var orderRepo = p.Provider.GetService<IOrderRepository>();

            var tvProductsIds = (await productRepo.GetProductsByCategoryId(4))
                .Select(product => product.id)
                .ToList();

            var tvOrderIds = (await itemsRepo.GetOrderItemsByProductIds(tvProductsIds))
                .Select(item => item.orderId)
                .Distinct()
                .ToList();

            var tvBuyerIds = (await orderRepo.GetOrdersByIds(tvOrderIds))
                .Select(order => order.userId)
                .Distinct()
                .ToList();

            var accessoryProductsIds = (await productRepo.GetProductsByCategoryId(6))
                .Select(product => product.id)
                .ToList();

            var accessoryOrderIds = (await itemsRepo.GetOrderItemsByProductIds(accessoryProductsIds))
                .Select(item => item.orderId)
                .Distinct()
                .ToList();

            var accessoryBuyerIds = (await orderRepo.GetOrdersByIds(accessoryOrderIds))
                .Select(order => order.userId)
                .Distinct()
                .ToList();

            tvBuyerIds.Should().BeSubsetOf(accessoryBuyerIds);
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
