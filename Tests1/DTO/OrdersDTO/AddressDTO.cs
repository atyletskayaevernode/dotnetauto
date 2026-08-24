using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.OrdersDTO
{
    public record AddressDTO
        (
        [property: JsonPropertyName("country")]
        string Country,

        [property: JsonPropertyName("city")]
        string City,

        [property: JsonPropertyName("street")]
        string Street,

        [property: JsonPropertyName("zip")]
        string Zip
        );
}
