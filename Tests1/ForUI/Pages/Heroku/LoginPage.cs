using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.Heroku
{
    public class LoginPage
    {
        private readonly IPage Page;

        private ILocator UsernameTextbox => Page.GetByRole(AriaRole.Textbox, new () { Name = "Username" });
        private ILocator PasswordTextbox => Page.GetByRole(AriaRole.Textbox, new () { Name = "Password" });
        private ILocator LoginButton => Page.GetByRole(AriaRole.Button, new () { Name = "Login" });
        private ILocator ErrorMsgLabel => Page.Locator("#flash");

        public LoginPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenLoginPageAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task FillLoginFormAsExistingUserAsync(string username, string password)
        {
            await UsernameTextbox.FillAsync(username);
            await PasswordTextbox.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        public async Task<string> GetErrorTextMsgFromLabelAsync()
        {
            return await ErrorMsgLabel.TextContentAsync();
        }
    }
}
