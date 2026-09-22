using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.DemoQA
{
    public class SelectMenuDemoQA
    {
        private readonly IPage Page;

        private ILocator SelectOneDropdown => Page.Locator("#selectOne");

        public SelectMenuDemoQA(IPage page)
        {
            Page = page;
        }

        public async Task OpenLoginPageAsync()
        {
            await Page.GotoAsync("https://demoqa.com/select-menu");
        }

        public async Task SelectOptionFromSelectOneDropdownAsync(string optionText)
        {
            await SelectOneDropdown.ClickAsync();
            var option = Page.GetByText(optionText);
            await option.ClickAsync();
        }
    }
}
