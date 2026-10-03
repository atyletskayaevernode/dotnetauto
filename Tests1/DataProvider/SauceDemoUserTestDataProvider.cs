using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.DataProvider
{
    public static class SauceDemoUserTestDataProvider
    {
        private const string UserDataFilePath = @"Resources\SauceDemoUsers.csv";

        public static IEnumerable<TestCaseData> AuthCases()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string fullPath = Path.Combine(baseDirectory, UserDataFilePath);

            var lines = File.ReadAllLines(fullPath);
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                string[] columns = line.Split(',');
                var username = columns[0];
                var password = columns[1];
                yield return new TestCaseData(username, password);  
            }
        }
    }
}
