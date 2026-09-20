using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.SauceDemo
{
    public class SauceDemoShoppingCartPage
    {
        private readonly IPage Page;
        private ILocator ItemName => Page.Locator("//div[@data-test='inventory-item-name']");
        private ILocator CheckoutButton => Page.Locator("//button[@data-test='checkout']");

        public SauceDemoShoppingCartPage(IPage page)
        {
            Page = page;
        }
        public async Task<IReadOnlyList<string>> GetItemNamesAsync()
        {
            return await ItemName.AllTextContentsAsync();
        }

        public async Task ClickCheckoutButtonAsync()
        {
            await CheckoutButton.ClickAsync();
        }
    }
}
