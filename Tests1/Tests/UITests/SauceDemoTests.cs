using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.ForUI.Pages.SauceDemo;

namespace Tests1.Tests.UITests
{
    public class SauceDemoTests : BaseTest
    {
        [Test]
        public async Task SuccessfulLogin_UserMovedToProductsPage()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");

            var usernameInput = Page.Locator("//input[@id='user-name']");
            await usernameInput.FillAsync("standard_user");

            var passwordInput = Page.Locator("//input[@id='password']");
            await passwordInput.FillAsync("secret_sauce");

            var loginButton = Page.Locator("//input[@id='login-button']");
            await loginButton.ClickAsync();

            var productsTitle = Page.Locator("//span[text()='Products']");
            (await productsTitle.IsVisibleAsync()).Should().BeTrue();
        }

        [Test]
        public async Task BuyTwoProductsAsync()
        {
            SauceDemoLoginPage loginPage = new SauceDemoLoginPage(Page);
            await loginPage.OpenLoginPageAsync();
            await loginPage.AuthoriseAsync("standard_user", "secret_sauce");
            bool isProductPageOpened = await Page.Locator("//span[text()='Products']").IsVisibleAsync();
            isProductPageOpened.Should().BeTrue();



        }
    }
}
