using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Enums;
using Tests1.Storages.Models;

namespace Tests1.ForUI.Pages.DemoQA
{
    public class AutomationPracticeFormDemoQA
    {
        private readonly IPage Page;
        private ILocator FirstNameInput => Page.Locator("//input[@id='firstName']");
        private ILocator LastNameInput => Page.Locator("//input[@id='lastName']");
        private ILocator EmailInput => Page.Locator("//input[@id='userEmail']");
        private ILocator GenderLabel(GenderType gender) =>
            Page.Locator($"//label[@for='gender-radio-{(int)gender + 1}']");
        private ILocator MobileInput => Page.Locator("//input[@id='userNumber']");
        private ILocator DateOfBirthInput => Page.Locator("//input[@id='dateOfBirthInput']");
        private ILocator DoBMonthSelect => Page.Locator("//select[contains(@class,'react-datepicker__month-select')]");
        private ILocator DoBYearSelect => Page.Locator("//select[contains(@class,'react-datepicker__year-select')]");
        private ILocator DoBDayInCalendar(DateTime date) =>
            Page.Locator($"//div[contains(@class,'react-datepicker__day--{date.Day:D3}') and not(contains(@class,'react-datepicker__day--outside-month'))]");
        private ILocator SubjectsInput => Page.Locator("//input[@id='subjectsInput']");
        private ILocator HobbyLabel(HobbyType hobby) =>
            Page.Locator($"//label[@for='hobbies-checkbox-{(int)hobby + 1}']");
        private ILocator UploadPicture => Page.Locator("//input[@id='uploadPicture']");
        private ILocator CurrentAddressInput => Page.Locator("//textarea[@id='currentAddress']");
        private ILocator StateInput => Page.Locator("//div[@id='state']//input");
        private ILocator CityInput => Page.Locator("//div[@id='city']//input");
        private ILocator SubmitButton => Page.Locator("//button[@id='submit']");
        private ILocator ModalTitle => Page.Locator("//*[contains(@class,'modal-title')]");
        private ILocator ResultValueByLabel(string label) =>
            Page.Locator($"//div[contains(@class,'modal-content')]//td[text()='{label}']/following-sibling::td");
        public AutomationPracticeFormDemoQA(IPage page)
        {
            Page = page;
        }
        public async Task OpenFormPageAsync()
        {
            await Page.GotoAsync("https://demoqa.com/automation-practice-form");
        }
        public async Task FillFormAsync(StudentRegistrationFormModel student)
        {
            await FirstNameInput.FillAsync(student.FirstName);
            await LastNameInput.FillAsync(student.LastName);
            await EmailInput.FillAsync(student.Email);
            await GenderLabel(student.Gender).ClickAsync();
            await MobileInput.FillAsync(student.MobileNumber);
            await FillDateOfBirthAsync(student.DateOfBirth);
            if (student.Subjects != null)
            {
                foreach (var subject in student.Subjects)
                {
                    await SubjectsInput.FillAsync(subject);
                    await SubjectsInput.PressAsync("Enter");
                }
            }
            if (student.Hobbies != null)
            {
                foreach (var hobby in student.Hobbies)
                {
                    await HobbyLabel(hobby).ClickAsync();
                }
            }
            if (!string.IsNullOrWhiteSpace(student.PicturePath))
            {
                await UploadPicture.SetInputFilesAsync(student.PicturePath);
            }
            await CurrentAddressInput.FillAsync(student.CurrentAddress);
            await StateInput.FillAsync(student.State);
            await StateInput.PressAsync("Enter");
            await CityInput.FillAsync(student.City);
            await CityInput.PressAsync("Enter");
        }

        public async Task SubmitAsync()
        {
            await Page.EvaluateAsync(@"() => {
                document.querySelector('#fixedban')?.remove();
                document.querySelector('footer')?.remove();
            }");
            await SubmitButton.ScrollIntoViewIfNeededAsync();
            await SubmitButton.ClickAsync();
        }

        public async Task<string> GetSuccessTitleAsync()
        {
            return await ModalTitle.TextContentAsync();
        }

        public async Task<string> GetResultValueAsync(string label)
        {
            return await ResultValueByLabel(label).TextContentAsync();
        }

        private async Task FillDateOfBirthAsync(DateTime date)
        {
            await DateOfBirthInput.ClickAsync();
            await DoBMonthSelect.SelectOptionAsync((date.Month - 1).ToString());
            await DoBYearSelect.SelectOptionAsync(date.Year.ToString());
            await DoBDayInCalendar(date).ClickAsync();
        }
    }
}
