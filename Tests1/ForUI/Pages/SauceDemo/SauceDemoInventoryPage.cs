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

        public SauceDemoInventoryPage(IPage page)
        {
            Page = page;
        }

        public async Task AddItemToCard()
        {

        }
    }
}
