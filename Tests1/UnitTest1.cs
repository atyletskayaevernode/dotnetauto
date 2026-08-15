using System.Net.Http.Json;
using System.Text.Json;
using Tests1.DTO;

namespace Tests1
{
    public class Tests
    {
        private static HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };

            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3HxNFNxHA5PT2D4rTd3FTeB0AOM");
        }

        [Test] //тест на проверку успешного статус кода на гет запрос
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();
        }

        [Test] //тест на проверку полей в респонсе на гет запрос - согласно UserResponseDTO
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
            UserDataDTO user = userResponse.Data;
        }

        [Test] //тест на создание юзера (по CreateUserRequestDTO) и наличие полей в респонсе (по CreateUserResponseSTO)
        public async Task Test3()
        {
            var createNewUserRequest = new CreateUserRequestDTO
            {
                Name = "Justus",
                Job = "Cheerful milkman"
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", createNewUserRequest);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDTO createdUser = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
        }

        [Test] //тест на успешный статус код при пут запросе
        public async Task Test4()
        {
            var updateUserRequest = new CreateUserRequestDTO
            {
                Name = "Justus",
                Job = "Internet celebrity"
            };
            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", updateUserRequest);
            response.EnsureSuccessStatusCode();
        }

        [Test] // тест на успешный статус код при delete запросе
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");
            response.EnsureSuccessStatusCode();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }


    }
}

