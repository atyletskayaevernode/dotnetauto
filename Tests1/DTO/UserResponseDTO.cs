using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO
{
    public class UserResponseDTO
    {
        [JsonPropertyName("data")]
        public UserDataDTO Data { get; set; }
    }
}