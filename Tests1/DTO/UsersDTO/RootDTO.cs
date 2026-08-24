using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.UsersDTO
{
    public record RootDTO 
        (
        [property: JsonPropertyName("data")] 
        IReadOnlyList<DataDTO> data
        );
}
