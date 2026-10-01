using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DataProvider;
using Tests1.Components;
using Tests1.DataProvider;

namespace Tests1.Tests
{
    // еще один тест с параметризацией, но теперь данные берутся из csv файла
    [TestFixture]
    public class EmailValidatorTests
    {
        [TestCaseSource(typeof(EmailTestDataProvider), 
            nameof(EmailTestDataProvider.GetEmailCases))]
        public void EmailValidationTest(string email, bool expectedResult)
        {
            bool actualResult = Validator.IsValid(email);
            Assert.That(expectedResult, Is.EqualTo(actualResult), 
                $"Email: {email}, Expected: {expectedResult}, Actual: {actualResult}");
        }
    }
}
