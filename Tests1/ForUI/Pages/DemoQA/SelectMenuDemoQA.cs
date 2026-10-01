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
        private ILocator SelectOneInput => SelectOneDropdown.Locator("input");
        private ILocator SelectOneSelectedValue => SelectOneDropdown.Locator("[class*='singleValue']");

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
            await SelectOneInput.FillAsync(optionText);
            await SelectOneInput.PressAsync("Enter");
        }

        public async Task CheckSelectedOptionInSelectOneAsync(string expectedOption)
        {
            await Assertions.Expect(SelectOneSelectedValue).ToHaveTextAsync(expectedOption);
        }
    }
}
