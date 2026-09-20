using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.ForUI.Pages.Heroku
{
    public class CheckboxesPage
    {
        private readonly IPage Page;

        private ILocator Checkbox => Page.Locator("input[type='checkbox']");

        public CheckboxesPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenCheckboxesPageAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/checkboxes");
        }

        public async Task<bool> GetStateOfCheckboxAsync(int number)
        {
            var state = await Checkbox.Nth(number - 1).IsCheckedAsync();
            return state;
        }

        public async Task UncheckCheckboxAsync(int number)
        {
            await Checkbox.Nth(number - 1).UncheckAsync();
        }

        public async Task CheckCheckboxAsync(int number)
        {
            await Checkbox.Nth(number - 1).CheckAsync();
        }

        public async Task CheckCheckboxesPageOpenAsync()
        {
            await Assertions.Expect(Page).ToHaveTitleAsync("The Internet");
            await Assertions.Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/checkboxes");
        }
    }
}
