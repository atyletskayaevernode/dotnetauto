using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.ForUI.Pages.DemoQA;

namespace Tests1.Tests.UITests
{
    public class DemoQATests : BaseTest
    {
        [Test]
        public async Task Dropdown_ShouldSelectSubItemAsync()
        {
            await Page.GotoAsync("https://demoqa.com/select-menu");

            var dropdown = Page.Locator("#withOptGroup");
            await dropdown.ClickAsync();

            var option = Page.GetByText("Group 1, option 1");
            await option.ClickAsync();
            await Assertions.Expect(dropdown).ToContainTextAsync("Group 1, option 1");
        }

        [Test]
        public async Task SelectOptionInTheDropdownSelectOne()
        {
            SelectMenuDemoQA selectMenuDemoQA = new SelectMenuDemoQA(Page);
            await selectMenuDemoQA.OpenLoginPageAsync();
            await selectMenuDemoQA.SelectOptionFromSelectOneDropdownAsync("Prof.");
        }
    }
}
