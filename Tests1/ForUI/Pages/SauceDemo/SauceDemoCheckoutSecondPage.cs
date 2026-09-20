using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.SauceDemo
{
    public class SauceDemoCheckoutSecondPage
    {
        private readonly IPage Page;
        private ILocator ItemName => Page.Locator("//div[@data-test='inventory-item-name']");
        private ILocator FinishButton => Page.Locator("//button[@data-test='finish']");
        private ILocator ItemPrice => Page.Locator("//div[@data-test='inventory-item-price']");

        public SauceDemoCheckoutSecondPage(IPage page)
        {
            Page = page;
        }

        public async Task ClickFinishButtonAsync()
        {
            await FinishButton.ClickAsync();
        }

        public async Task<IReadOnlyList<string>> GetItemNamesAsync()
        {
            return await ItemName.AllTextContentsAsync();
        }

        public async Task<IReadOnlyList<string>> GetItemPricesAsync()
        {
            return await ItemPrice.AllTextContentsAsync();
        }
    }
}
