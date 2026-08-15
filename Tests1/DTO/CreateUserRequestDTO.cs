using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO
{
    public class CreateUserRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
