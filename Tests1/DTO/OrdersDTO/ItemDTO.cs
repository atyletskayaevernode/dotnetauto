using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.OrdersDTO
{
    public record ItemDTO
        (
        [property: JsonPropertyName("productId")]
        int ProductId,

        [property: JsonPropertyName("name")]
        string Name,

        [property: JsonPropertyName("category")]
        string Category,

        [property: JsonPropertyName("quantity")]
        int Quantity,

        [property: JsonPropertyName("price")]
        decimal Price
        );
}
