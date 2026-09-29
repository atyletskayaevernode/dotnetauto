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
        private ILocator ItemNameText => Page.Locator("[data-test='inventory-item-name']");
        private ILocator ItemPriceText => Page.Locator("[data-test='inventory-item-price']");
        private ILocator AddToCartButton => Page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" });
        private ILocator InventoryItemByName(string itemName) => InventoryItem.Filter(new()
        {
        Has = ItemNameText.GetByText(itemName, new() { Exact = true })
        });

        public SauceDemoInventoryPage(IPage page)
        {
            Page = page;
        }

        public async Task<bool> IsProductsPageOpenedAsync()
        {
            return await ProductsTitle.IsVisibleAsync();
        }

        public async Task AddItemToCartAsync(string itemName)
        {
            await InventoryItemByName(itemName).Locator(AddToCartButton).ClickAsync();
        }

        public async Task ClickCartIconAsync()
        {
            await CartIcon.ClickAsync();
        }

        public async Task<string> GetItemPriceAsync(string itemName)
        {
            return await InventoryItemByName(itemName).Locator(ItemPriceText).TextContentAsync();
        }
    }
}
