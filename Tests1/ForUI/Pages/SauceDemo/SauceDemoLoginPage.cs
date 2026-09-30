using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.SauceDemo
{
    public class SauceDemoLoginPage
    {
        private readonly IPage Page;

        private ILocator UsernameTextbox => Page.Locator("//input[@id='user-name']");
        private ILocator PasswordTextbox => Page.Locator("//input[@id='password']");
        private ILocator LoginButton => Page.Locator("//input[@id='login-button']");

        public SauceDemoLoginPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenLoginPageAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task AuthoriseAsync(string username, string password)
        {
            await UsernameTextbox.FillAsync(username);
            await PasswordTextbox.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}
