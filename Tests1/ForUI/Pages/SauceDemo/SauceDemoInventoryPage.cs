using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.SauceDemo
{
    public class SauceDemoInventoryPage
    {
        private readonly IPage Page;
        private ILocator ProductsTitle => Page.Locator("//span[text()='Products']");
        private ILocator InventoryItem => Page.Locator("//div[@data-test='inventory-item']");
        private ILocator CartIcon => Page.Locator("//a[@data-test='shopping-cart-link']");

        public SauceDemoInventoryPage(IPage page)
        {
            Page = page;
        }

        public async Task<bool> IsProductsPageOpenedAsync()
        {
            return await ProductsTitle.IsVisibleAsync();
        }

        public async Task AddItemToCartAsync(int itemIndex)
        {
            await InventoryItem.Nth(itemIndex).Locator("xpath=.//button[text()='Add to cart']").ClickAsync();
        }

        public async Task ClickCartIcon()
        {
            await CartIcon.ClickAsync();
        }

        public async Task<string> GetItemNameAsync(int itemIndex)
        {
            return await InventoryItem.Nth(itemIndex)
                .Locator("xpath=.//div[@data-test='inventory-item-name']")
                .TextContentAsync();
        }
    }
}
