using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Tests1.DTO.UsersDTO;
using Tests1.Helpers;

namespace Tests1.Tests
{
    public class UserDataJsonTests
    {
        private RootDTO root;

        [OneTimeSetUp]
        public void Setup()
        {
            root = FileReader.ReadJson<RootDTO>("UserData.json");
        }

        [Test] // 2.1 Проверить, что количество юзеров из файла равно 10
        public void Test1_UsersCountIs10()
        {
            root.data.Should().HaveCount(10);
        }

        [Test] // 2.2 Проверить, что первый юзер - Alice Johnson
        public void Test2_FirstUserFullNameIsAliceJohnson()
        {
            root.data.First().profile.fullName.Should().Be("Alice Johnson");
        }

        [Test] // 2.3 Проверить, что все Id уникальны
        public void Test3_AllUserIdsAreUnique()
        {
            var usersIds = root.data.Select(user => user.id).ToList();
            usersIds.Should().OnlyHaveUniqueItems();
        }

        [Test] // 2.4 Проверить, что есть хотя бы один премиум-пользователь
        public void Test4_AtLeastOneIsPremiumUser()
        {
            var atLeastOneWithPremium = root.data.Any(user => user.profile.tags.Contains("premium"));
            atLeastOneWithPremium.Should().BeTrue();
        }

        [Test] // 2.5 Проверить, что у всех юзеров поле город - не пустой
        public void Test5_AllUsersHaveFilledCities()
        {
            var allCitiesFilled = root.data.All(user => !string.IsNullOrWhiteSpace(user.profile.address.city));
            allCitiesFilled.Should().BeTrue();
        }

        [Test] // 2.6 Проверить, что есть хотя бы один пользователь из Стокгольма
        public void Test6_AtLeastOneUserIsFromStockholm()
        {
            var atLeastOneFromStockholm = root.data.Any(user => user.profile.address.city == "Stockholm");
            atLeastOneFromStockholm.Should().BeTrue();
        }

        [Test] // 2.7 Проверить, что возраст всех юзеров в диапазоне 18-60 лет
        public void Test7_AllAgesAreBetween18And60()
        {
            var allUsersAgesInRange = root.data.All(user => user.profile.age >= 18 && user.profile.age <= 60);
            allUsersAgesInRange.Should().BeTrue();
        }

        [Test] // 2.8 Проверить, что есть хотя бы один юзер с ролью admin
        public void Test8_AtLeastOneUserIsAdmin()
        {
            var atLeastOneIsAdmin = root.data.Any(user => user.roles.Contains("admin"));
            atLeastOneIsAdmin.Should().BeTrue();
        }

        [Test] // 3. Проверить, что все юзеры (их координаты) находятся в диапазоне Швеции
        public async Task Test9_AllUsersCoordinatesAreInSweden() 
        {
            var nominatim = new NominatimClient();
            foreach (var user in root.data)
            {
                var countryCode = await nominatim.GetCountryCodeAsync(
                    user.profile.address.geo.lat,
                    user.profile.address.geo.lng);
                countryCode.Should().Be("se");
            }
        }
    }
}
