using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
        (
        long id,

        string orderId,

        string productId,

        long quantity,

        long unitPrice
        );
}
    