using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.SauceDemo
{
    public class SauceDemoCheckoutCompletePage
    {
        private readonly IPage Page;
        private ILocator CompleteHeader => Page.Locator("//h2[@data-test='complete-header']");

        public SauceDemoCheckoutCompletePage(IPage page)
        {
            Page = page;
        }

        public async Task<string> GetCompleteHeaderTextAsync()
        {
            return await CompleteHeader.TextContentAsync();
        }
    }
}
