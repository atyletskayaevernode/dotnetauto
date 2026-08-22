using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.UsersDTO
{
    public record ProfileDTO 
        (
        [property: JsonPropertyName("fullName")] 
        string fullName,

        [property: JsonPropertyName("age")] 
        int age,

        [property: JsonPropertyName("address")] 
        Address address,

        [property: JsonPropertyName("tags")] 
        IReadOnlyList<string> tags
        );
}
