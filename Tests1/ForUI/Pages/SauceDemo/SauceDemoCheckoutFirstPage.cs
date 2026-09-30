using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.SauceDemo
{
    public class SauceDemoCheckoutFirstPage
    {
        private readonly IPage Page;
        private ILocator FirstNameInput => Page.Locator("//input[@id='first-name']");
        private ILocator LastNameInput => Page.Locator("//input[@id='last-name']");
        private ILocator PostalCodeInput => Page.Locator("//input[@id='postal-code']");
        private ILocator ContinueButton => Page.Locator("//input[@data-test='continue']");

        public SauceDemoCheckoutFirstPage(IPage page)
        {
            Page = page;
        }

        public async Task FillCheckoutInformationAsync(string firstName, string lastName, string postalCode)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await PostalCodeInput.FillAsync(postalCode);
        }

        public async Task ClickContinueButtonAsync()
        {
            await ContinueButton.ClickAsync();
        }
    }
}
