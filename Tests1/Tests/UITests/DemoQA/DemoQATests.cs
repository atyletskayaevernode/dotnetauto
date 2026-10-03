using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tests1.Enums;
using Tests1.ForUI.Pages.DemoQA;
using Tests1.Storages.Builders;
using Tests1.Storages.Models;

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
        public async Task FormTest()
        {
            var picturePath = Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                "Resources",
                "glowing-blue-jellyfish-stockcake.jpg");
            var student = new StudentRegistrationBuilder()
                .WithName("Jane", "Doe")
                .WithEmail("jane.doe@example.com")
                .WithGender(GenderType.Female)
                .WithMobileNumber("1234567890")
                .WithDateOfBirth(new DateTime(1990, 11, 12))
                .WithSubjects("Biology", "Maths")
                .WithHobbies(HobbyType.Reading, HobbyType.Music)
                .WithPicture(picturePath)
                .WithCurrentAddress("221B Baker Street")
                .WithStateAndCity("NCR", "Delhi")
                .Build();
            var form = new AutomationPracticeFormDemoQA(Page);
            await form.OpenFormPageAsync();
            await form.FillFormAsync(student);
            await form.SubmitAsync();
            (await form.GetSuccessTitleAsync())
                .Should().Be("Thanks for submitting the form");
            var expectedDate = student.DateOfBirth.ToString("d MMMM,yyyy", CultureInfo.GetCultureInfo("en-US"));
            using (new AssertionScope())
            {
                (await form.GetResultValueAsync("Student Name"))
                    .Should().Be($"{student.FirstName} {student.LastName}");
                (await form.GetResultValueAsync("Student Email"))
                    .Should().Be(student.Email);
                (await form.GetResultValueAsync("Gender"))
                    .Should().Be(student.Gender.ToString());
                (await form.GetResultValueAsync("Mobile"))
                    .Should().Be(student.MobileNumber);
                (await form.GetResultValueAsync("Date of Birth"))
                    .Should().Be(expectedDate);
                (await form.GetResultValueAsync("Subjects"))
                    .Should().Be(string.Join(", ", student.Subjects));
                (await form.GetResultValueAsync("Hobbies"))
                    .Should().Be(string.Join(", ", student.Hobbies));
                (await form.GetResultValueAsync("Picture"))
                    .Should().Be(Path.GetFileName(student.PicturePath));
                (await form.GetResultValueAsync("Address"))
                    .Should().Be(student.CurrentAddress);
                (await form.GetResultValueAsync("State and City"))
                    .Should().Be($"{student.State} {student.City}");
            }
        }
    }
}