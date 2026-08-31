using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.DapperTestsDTO
{
    public record ProductDTO
        (
        long id,

        string name,

        string description,

        double price,

        long stock,

        long categoryId
        );
}