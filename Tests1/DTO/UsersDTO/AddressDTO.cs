using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.UsersDTO
{
    public record AddressDTO
        (
        [property: JsonPropertyName("street")] 
        string street,

        [property: JsonPropertyName("city")] 
        string city,

        [property: JsonPropertyName("geo")] 
        GeoDTO geo
        );
        
        
}
