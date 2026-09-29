using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Components;

namespace Tests1.Tests.ParameterTests
{
    public class CalculatorTest // параметризованные автотесты
    {
        [Test]
        public void AddSumTest001() // исходный тест
        {
            Calculator calc = new Calculator();
            int result = calc.Add(1, 6);
            Assert.That(result, Is.EqualTo(7),
                $"Expected: 7, but result is {result}, a = 1, b = 6");

        }

        [TestCase(1, 6, 7)] //аналогичный параметризованный тест кейс. Передаем все параметры сюда
        [TestCase(1, 2, 3)]
        [TestCase(1, -5, -4)]

        public void AddSumTest002(int a, int b, int c)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(a, b);
            Assert.That(c, Is.EqualTo(result),
                $"Expected: {c}, but result is {c}, a = {a}, b = {b}");

        }
    }
}
