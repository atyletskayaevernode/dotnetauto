using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Interfaces.DapperTestsInterfaces;
using Tests1.DTO;
using Tests1.DTO.DapperTestsDTO;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Tests1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connection;
        public UserRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            using var db = new SqliteConnection(connection);
            var users = await db.QueryAsync<UserDTO>("SELECT * from Users");
            return users;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            using var db = new SqliteConnection(connection);
            var userById = await db.QueryFirstOrDefaultAsync<UserDTO>("SELECT * from Users " +
                "WHERE Id = @id", new { id });
            return userById;
        }

        public async Task<UserDTO> GetUserByNameAndSurname(string firstName, string lastName)
        {
            using var db = new SqliteConnection(connection);
            var userByName = await db.QueryFirstOrDefaultAsync<UserDTO>("SELECT * from Users" +
                " WHERE FirstName = @firstName AND LastName = @lastName", new { firstName, lastName });
            return userByName;
        }
    }
}
