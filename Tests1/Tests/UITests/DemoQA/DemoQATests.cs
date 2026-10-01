using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.ForUI.Pages.DemoQA;
using Tests1.Storages.Models;
using Tests1.Storages.Builders;
using Tests1.Enums;

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

        [Test]
        public async Task SelectOptionInTheDropdownSelectOne()
        {
            SelectMenuDemoQA selectMenuDemoQA = new SelectMenuDemoQA(Page);

            await selectMenuDemoQA.OpenLoginPageAsync();
            await selectMenuDemoQA.SelectOptionFromSelectOneDropdownAsync("Prof.");
            await selectMenuDemoQA.CheckSelectedOptionInSelectOneAsync("Prof.");
        }

        [Test]
        public async Task FormTest() //тест на заполнение формы https://demoqa.com/automation-practice-form
        {
            var builder = new StudentRegistrationBuilder();
            var student = builder.WithName("Jane", "Doe")
                                 .WithEmail("jane.doe@example.com")
                                 .WithGender(GenderType.Female)
                                 .WithMobileNumber("1234567890")
                                 .WithDateOfBirth(new DateTime(1990, 11, 12))
                                 //и т.д. для всех остальных полей
                                 .Build();


        }
    }
}