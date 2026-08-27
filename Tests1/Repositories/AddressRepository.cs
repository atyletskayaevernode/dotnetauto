using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;
using Tests1.Interfaces.DapperTestsInterfaces;

namespace Tests1.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connection;
        public AddressRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<AddressDTO> GetAddressByUserId(int userId)
        {
            using var db = new SqliteConnection(connection);
            var address = await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * from Addresses " +
                "WHERE UserId = @userId", new { userId });
            return address;
        }
    }
}
