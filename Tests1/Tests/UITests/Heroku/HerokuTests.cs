using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.ForUI.Pages.Heroku;

namespace Tests1.Tests.UITests.Heroku
{
    public class HerokuTests : BaseTest
    {
        [Test]
        public async Task CheckBoxesCheckDefaultStatesAndCheckUncheckAsync()
        {
            CheckboxesPage checkboxesPage = new CheckboxesPage(Page);

            // Открываем страницу
            await checkboxesPage.OpenCheckboxesPageAsync();
            await checkboxesPage.CheckCheckboxesPageOpenAsync();

            // --- Проверка дефолтного состояния ---
            bool stateOfFirstCheckbox = await checkboxesPage.GetStateOfCheckboxAsync(1);
            bool stateOfSecondCheckbox = await checkboxesPage.GetStateOfCheckboxAsync(2);
            stateOfFirstCheckbox.Should().BeFalse();
            stateOfSecondCheckbox.Should().BeTrue();

            // --- ДЕЙСТВИЕ 1: отщёлкнуть второй чекбокс ---
            await checkboxesPage.UncheckCheckboxAsync(2);

            // Проверка после действия
            stateOfSecondCheckbox = await checkboxesPage.GetStateOfCheckboxAsync(2);
            stateOfSecondCheckbox.Should().BeFalse();

            // --- ДЕЙСТВИЕ 2: щёлкнуть первый чекбокс ---
            await checkboxesPage.CheckCheckboxAsync(1);

            // Проверка после действия
            stateOfFirstCheckbox = await checkboxesPage.GetStateOfCheckboxAsync(1);
            stateOfFirstCheckbox.Should().BeTrue();

            // --- ДЕЙСТВИЕ 3: вернуть второй обратно ---
            await checkboxesPage.CheckCheckboxAsync(2);

            // Проверка после действия
            stateOfSecondCheckbox = await checkboxesPage.GetStateOfCheckboxAsync(2);
            stateOfSecondCheckbox.Should().BeTrue();
        }

        [Test]
        public async Task FormAuthentification_AuthoriseWithWrongPasswordAsync()
        {
            LoginPage loginPage = new LoginPage(Page);
            await loginPage.OpenLoginPageAsync();

            await loginPage.FillLoginFormAsExistingUserAsync("nottomsmith", "SuperSecretPassword!");

            string errorMessage = await loginPage.GetErrorTextMsgFromLabelAsync();

            errorMessage.Should().Contain("Your username is invalid!");
        }

        [Test]
        public async Task DropdownPageAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/dropdown");

            await Assertions.Expect(Page).ToHaveTitleAsync("The Internet");
            await Assertions.Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/dropdown");

            var dropdown = Page.Locator("#dropdown");
            await Assertions.Expect(dropdown).ToBeVisibleAsync();

            await dropdown.SelectOptionAsync("1"); //выбираем в дропдауне по value из верстки, который соответствует опции "Option 1"

            //1-й способ проверить, что выбрана нужная опция: проверка, что в дропдауне стоит опция с этим велью
            await Assertions.Expect(dropdown).ToHaveValueAsync("1");

            //2-й способ: получение опции из дропдауна, которая выбрана и сравнение текста
            var selectedOption = dropdown.Locator("option:checked");
            await Assertions.Expect(selectedOption).ToHaveTextAsync("Option 1");

            await dropdown.SelectOptionAsync("2");
            await Assertions.Expect(selectedOption).ToHaveTextAsync("Option 2");
        }

        [Test]
        public async Task LeftAndBottomFramesTestAsync()
        {
            FramesPage framesPage = new FramesPage(Page);
            await framesPage.OpenFramesPageAsync();
            await framesPage.ClickNestedFramesLinkAsync();
            NestedFramesPage nestedFramesPage = new NestedFramesPage(Page);

            var textFromLeftFrame = await nestedFramesPage.GetTextFromLeftFrameAsync();
            textFromLeftFrame.Should().Contain("LEFT");

            var textFromBottomFrame = await nestedFramesPage.GetTextFromBottomFrameAsync();
            textFromBottomFrame.Should().Contain("BOTTOM");
        }

        [Test]
        public async Task OpenLinkInTheNewWindowAsync()
        {
            MultipleWindowPage multipleWindowPage = new MultipleWindowPage(Page);
            await multipleWindowPage.OpenMultipleWindowPageAsync();
            var newWindow = await multipleWindowPage.OpenNewWindowAsync();
            await Assertions.Expect(newWindow.Locator("h3")).ToHaveTextAsync("New Window"); // по-хорошему надо было в пейдж обджекте, но времени не было
            newWindow.Url.Should().Contain("windows/new");
        }

        [Test]
        public async Task JsRegularAlertTest()
        {
            JSAlertsPage jsAlertPage = new JSAlertsPage(Page);
            jsAlertPage.OpenAlertsPageAsync();

            IDialog actualDialog = null;
            //Пишем обработчик алертов. Пишется прямо в тесте, но по факту должен быть в обертке / в хелперах
            //подписываемся на событие появления алерта (Page.Dialog - событие).
            //когда появляется аллерт - выполни такое-то действие
            Page.Dialog += async (_, dialog) =>
            {
                actualDialog = dialog;
                await actualDialog.AcceptAsync(); //жмет кнопку OK в алерте. В случае, если алерт c кнопкой отменить и нужно нажать ее - есть DismissAync();
            };

            await jsAlertPage.ClickFirstAlertButtonAsync();

            actualDialog.Should().NotBeNull();
            actualDialog.Type.Should().Be("alert");
            actualDialog.Message.Should().Be("I am a JS Alert");
            var resultText = await jsAlertPage.GetResultTextAsync();
            resultText.Should().Be("You successfully clicked an alert");
        }

        [Test]
        public async Task JsAlertWithTextboxTest()
        {
            JSAlertsPage jsAlertPage = new JSAlertsPage(Page);
            jsAlertPage.OpenAlertsPageAsync();

            var textForAlert = "Test123";

            IDialog actualDialog = null;
            Page.Dialog += async (_, dialog) =>
            {
                actualDialog = dialog;
                await actualDialog.AcceptAsync(textForAlert);
            };

            await jsAlertPage.ClickThirdAlertButtonAsync();

            actualDialog.Should().NotBeNull();
            actualDialog.Type.Should().Be("prompt");
            actualDialog.Message.Should().Be("I am a JS prompt");
            var resultText = await jsAlertPage.GetResultTextAsync();
            resultText.Should().Be("You entered: Test123");
        }
    }
}
