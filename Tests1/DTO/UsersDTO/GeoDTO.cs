using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.UsersDTO
{
    public record GeoDTO
        (
        [property: JsonPropertyName("lat")]
        double lat,

        [property: JsonPropertyName("lng")]
        double lng
        );
}
