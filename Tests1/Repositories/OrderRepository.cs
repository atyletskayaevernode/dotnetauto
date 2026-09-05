using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Interfaces.DapperTestsInterfaces;
using Tests1.DTO.DapperTestsDTO;
using Dapper;

namespace Tests1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connection;
        public OrderRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<OrderDTO> GetOrderByUserId(int userId, int id)
        {
            using var db = new SqliteConnection(connection);
            var order = await db.QueryFirstOrDefaultAsync<OrderDTO>("SELECT * from Orders " +
                "WHERE UserId = @userId AND Id = @id", new { userId, id });
            return order;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByIds(IEnumerable<long> ids)
        {
            using var db = new SqliteConnection(connection);
            var orders = await db.QueryAsync<OrderDTO>(
                "SELECT * from Orders WHERE Id IN @ids",
                new { ids });
            return orders;
        }
    }
}
