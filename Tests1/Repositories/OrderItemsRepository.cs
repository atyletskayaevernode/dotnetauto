using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;
using Tests1.Interfaces.DapperTestsInterfaces;

namespace Tests1.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly string connection;
        public OrderItemsRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByOrderId(int orderId)
        {
            using var db = new SqliteConnection(connection);
            var items = await db.QueryAsync<OrderItemsDTO>("SELECT * from OrderItems " +
                "WHERE OrderId = @orderId", new { orderId });
            return items;
        }
    }
}
