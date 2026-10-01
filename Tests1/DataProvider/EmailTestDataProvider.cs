using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.DataProvider
{
    //обязательнео статический класс и методы, чтобы их можно было использовать в TestCaseSource
    public static class EmailTestDataProvider
    {
        private const string EmailDataFilePath = @"Resources\Email.csv";

        public static IEnumerable<TestCaseData> GetEmailCases()
        {
            //получаем директорию, в которой исполняется процесс запуска автотестов
            string baseDirectory = AppContext.BaseDirectory;

            //формируем полный путь к файлу csv
            string fullPath = Path.Combine(baseDirectory, EmailDataFilePath);

            //читаем все строки из файла
            var lines = File.ReadAllLines(fullPath);

            for (int i = 1; i < lines.Length; i++) // пропускаем заголовок
            {
                var line= lines[i];
                string[] columns = line.Split(',');
                var email = columns[0];
                bool expectedResult = bool.Parse(columns[1]);
                yield return new TestCaseData(email, expectedResult);

            }
        }
    }
}
