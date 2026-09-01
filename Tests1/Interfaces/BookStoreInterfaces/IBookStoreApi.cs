using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.BookStoreDTO;
using Refit;

namespace Tests1.Interfaces.BookStoreInterfaces
{
    public interface IBookStoreApi
    {
        [Post("/Account/v1/User")]
        Task<UserCreateResponseDTO> CreateUserAsync([Body] UserCreateRequestDTO credentials);

        [Post("/Account/v1/GenerateToken")]
        Task<GenerateTokenResponseDTO> GenerateTokenAsync([Body] UserCreateRequestDTO credentials);
    }
}
