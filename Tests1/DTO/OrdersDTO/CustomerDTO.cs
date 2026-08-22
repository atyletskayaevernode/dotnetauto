using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.OrdersDTO
{
    public record CustomerDTO
        (
        [property: JsonPropertyName("id")]
        int Id,

        [property: JsonPropertyName("name")]
        string Name,

        [property: JsonPropertyName("email")]
        string Email,

        [property: JsonPropertyName("phone")]
        string Phone,

        [property: JsonPropertyName("address")]
        AddressDTO Address
        );
}
