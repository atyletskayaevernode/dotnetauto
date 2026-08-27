using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;

namespace Tests1.Interfaces.DapperTestsInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId (int userId);
    }
}
