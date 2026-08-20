using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Tests1.DTO;
using Tests1.DTO.OrdersDTO;

namespace Tests1.Tests
{
    public class OrderJsonTests
    {
        private OrderDTO order;

        [OneTimeSetUp]
        public void Setup()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "OrderData.json");
            string json = File.ReadAllText(path);

            order = JsonSerializer.Deserialize<OrderDTO>(json);
        }

        [Test]  //тест на проверку товаров - они есть и их 3
        public void Test1_CheckItemsIsNotNull()
        {
            foreach (var item in order.Items)
            {
                TestContext.WriteLine($"{item.ProductId} | {item.Quantity.ToString()} | {item.Price.ToString()}");
            }

            order.Items.Should().NotBeNull();
            order.Items.Should().HaveCount(3);
        }

        [Test] // подсчет стоимости всех товаров - соответствует тому, что в summary.itemsTotal

        public void Test2_CheckSumOfitems()
        {
            var sum = order.Items.Select(item => item.Quantity * item.Price).Sum();
            sum.Should().Be(order.Summary.ItemsTotal);
        }

        [Test] // в ордере есть 2 айтема категории "Electronics"

        public void Test3_CheckElectronicsQuantity()
        {
            var electronicsInOrder = order.Items.Where(item => item.Category == "Electronics").ToList();

            using (new AssertionScope())
            {
                electronicsInOrder.Should().OnlyContain(item => item.Category == "Electronics");
                electronicsInOrder.Should().HaveCount(2);
            }
        }
    }
}
