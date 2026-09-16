using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
