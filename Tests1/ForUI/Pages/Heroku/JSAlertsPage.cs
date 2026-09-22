using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.Heroku
{
    public class JSAlertsPage
    {
        private readonly IPage Page;
        private ILocator JsAlertButton => Page.GetByRole(AriaRole.Button, new() { Name = "Click for JS Alert" });
        private ILocator JsPromptButton => Page.GetByRole(AriaRole.Button, new() { Name = "Click for JS Prompt" });
        private ILocator ResultLabel => Page.Locator("#result");


        public JSAlertsPage (IPage page)
        {
            Page = page;
        }

        public async Task OpenAlertsPageAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/javascript_alerts");
        }

        public async Task ClickFirstAlertButtonAsync()
        {
            await JsAlertButton.ClickAsync();
        }

        public async Task<string> GetResultTextAsync()
        {
            return await ResultLabel.InnerTextAsync();
        }

        public async Task ClickThirdAlertButtonAsync()
        {
            await JsPromptButton.ClickAsync();
        }
    }
}
