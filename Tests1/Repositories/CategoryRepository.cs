using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;
using Tests1.Interfaces.DapperTestsInterfaces;

namespace Tests1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connection;
        public CategoryRepository(string connection)
        {
            this.connection = connection;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            using var db = new SqliteConnection(connection);
            var categories = await db.QueryAsync<CategoryDTO>("SELECT * from Categories");
            return categories;
        }
    }
}
