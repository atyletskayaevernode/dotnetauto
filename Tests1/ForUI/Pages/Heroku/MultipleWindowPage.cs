using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.Heroku
{
    public class MultipleWindowPage
    {
        private readonly IPage Page;

        private ILocator CLickHereLink => Page.GetByRole(AriaRole.Link, new() { Name = "Click Here" });

        public MultipleWindowPage (IPage page)
        {
            Page = page;
        }

        public async Task OpenMultipleWindowPageAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/windows");
        }

        public async Task<IPage> OpenNewWindowAsync()
        {
            // пример делегата
            return await Page.RunAndWaitForPopupAsync(async () =>
            await CLickHereLink.ClickAsync()
            );
        }
    }
}
