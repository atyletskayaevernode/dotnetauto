using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.Hooks
{
    public class HooksForTestGroup : GlobalSetUpAndTearDown
    {
        [OneTimeSetUp]
        public void OneTimeSetUpForOneGroup()
        {
            //Console.WriteLine("Hook for test group (e.g. SauceDemoTests) - once befire tests in the one group");
        }

        [SetUp]
        public void SetUpForOneGroup()
        {
            //Console.WriteLine("Hook for test group (e.g. SauceDemoTests) - before every test in the one group");
        }

        [OneTimeTearDown]
        public void OneTimeTearDownForOneGroup()
        {
            //Console.WriteLine("Hook for test group (e.g. SauceDemoTests) - once after all tests in the one group");
        }

        [TearDown]
        public void TearDownForOneGroup()
        {
            //Console.WriteLine("Hook for test group (e.g. SauceDemoTests) - after every test in the one group");
        }
    }
}
