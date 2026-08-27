using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Tests1.DTO.UsersDTO;

namespace Tests1.DTO.DapperTestsDTO
{
    public record UserDTO
        (
        long id,

        string firstName,

        string lastName,

        string email,

        string phone,

        string createdAt
        );
}
