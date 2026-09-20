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

            SauceDemoInventoryPage inventoryPage = new SauceDemoInventoryPage(Page);
            bool isProductPageOpened = await inventoryPage.IsProductsPageOpenedAsync();
            isProductPageOpened.Should().BeTrue();
            string firstItem = await inventoryPage.GetItemNameAsync(0);
            string thirdItem = await inventoryPage.GetItemNameAsync(2);
            await inventoryPage.AddItemToCartAsync(0);
            await inventoryPage.AddItemToCartAsync(2);
            await inventoryPage.ClickCartIcon();

            SauceDemoShoppingCartPage cartPage = new SauceDemoShoppingCartPage(Page);
            IReadOnlyList<string> itemsInCart = await cartPage.GetItemNamesAsync();
            itemsInCart.Should().Contain(firstItem);
            itemsInCart.Should().Contain(thirdItem);
            await cartPage.ClickCheckoutButtonAsync();

            SauceDemoCheckoutFirstPage checkoutFirstPage = new SauceDemoCheckoutFirstPage(Page);
            await checkoutFirstPage.FillCheckoutInformationAsync("Ivan", "Ivanov", "12345");
            await checkoutFirstPage.ClickContinueButtonAsync();

            SauceDemoCheckoutSecondPage checkoutSecondPage = new SauceDemoCheckoutSecondPage(Page);
            IReadOnlyList<string> itemsOnOverview = await checkoutSecondPage.GetItemNamesAsync();
            itemsOnOverview.Should().Contain(firstItem);
            itemsOnOverview.Should().Contain(thirdItem);
            await checkoutSecondPage.ClickFinishButtonAsync();

            SauceDemoCheckoutCompletePage checkoutCompletePage = new SauceDemoCheckoutCompletePage(Page);
            string completeHeaderText = await checkoutCompletePage.GetCompleteHeaderTextAsync();
            completeHeaderText.Should().Be("Thank you for your order!");

        }
    }
}
