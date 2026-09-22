using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.Tests.UITests.DemoQA
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
    }
}
