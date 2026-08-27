using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.DapperTestsDTO
{
    public record OrderDTO
        (
        int id,

        string userId,

        string orderDate,

        int status,

        int totalPrice
        );
}