using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;

namespace Tests1.Interfaces.DapperTestsInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderByUserId(int userId, int orderId);

        Task<IEnumerable<OrderDTO>> GetOrdersByIds(IEnumerable<long> ids);
    }
}
