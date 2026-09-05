using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Tests1.DTO.DapperTestsDTO;
using Tests1.Interfaces.DapperTestsInterfaces;

namespace Tests1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connection;
        public ProductRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            using var db = new SqliteConnection(connection);
            var productById = await db.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * from Products " +
                "WHERE Id = @id", new { id });
            return productById;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId)
        {
            using var db = new SqliteConnection(connection);
            var products = await db.QueryAsync<ProductDTO>(
                "SELECT * from Products WHERE CategoryId = @categoryId",
                new { categoryId });
            return products;
        }
    }
}
