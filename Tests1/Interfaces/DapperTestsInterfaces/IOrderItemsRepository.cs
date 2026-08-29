using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;

namespace Tests1.Interfaces.DapperTestsInterfaces
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByOrderId(int orderId);
    }
}
