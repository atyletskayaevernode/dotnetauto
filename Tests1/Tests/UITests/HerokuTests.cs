using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.Tests.UITests
{
    public class HerokuTests : BaseTest
    {
        [Test]
        public async Task CheckBoxTest()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/checkboxes");
            var first = Page.Locator("input[type='checkbox']").Nth(0);
            await first.CheckAsync();
            (await first.IsCheckedAsync()).Should().BeTrue();
        }

        [Test]
        public async Task FormAuthentification_AuthoriseWithWrongPasswordAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/login");

            var usernameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }); //playwright локатор
            await usernameTextBox.FillAsync("nottomsmith");

            //var passwordTextBox = Page.Locator("#password"); //css локатор вариация 1
            var passwordTextBox = await Page.QuerySelectorAsync("#password"); //ccs локатор вариация 2
            await passwordTextBox.FillAsync("SuperSecretPassword!");

            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" }); //playwright локатор
            await loginButton.ClickAsync();

            var errorMessageLabel = Page.Locator("//div[@id='flash']"); //x-path локатор
            var errorMessageText = await errorMessageLabel.TextContentAsync();

            errorMessageText.Should().Contain("Your username is invalid!");
        }

        [Test]
        public async Task DropdownPageAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/dropdown");

            await Assertions.Expect(Page).ToHaveTitleAsync("The Internet");
            await Assertions.Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/dropdown");

            var dropdown = Page.Locator("#dropdown");
            await Assertions.Expect(dropdown).ToBeVisibleAsync();

            await dropdown.SelectOptionAsync("1"); //выбираем в дропдауне по value из верстки, который соответствует опции "Option 1"

            //1-й способ проверить, что выбрана нужная опция: проверка, что в дропдауне стоит опция с этим велью
            await Assertions.Expect(dropdown).ToHaveValueAsync("1");

            //2-й способ: получение опции из дропдауна, которая выбрана и сравнение текста
            var selectedOption = dropdown.Locator("option:checked");
            await Assertions.Expect(selectedOption).ToHaveTextAsync("Option 1");

            await dropdown.SelectOptionAsync("2");
            await Assertions.Expect(selectedOption).ToHaveTextAsync("Option 2");
        }


    }
}
