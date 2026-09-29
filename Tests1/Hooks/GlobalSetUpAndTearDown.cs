using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.Hooks
{
    [SetUpFixture] //вариант, как можно вынести сетапы и тирдауны в отдельный класс
    public class GlobalSetUpAndTearDown 
    {
        [OneTimeSetUp]
        public void GlobalOneTimeSetUp()
        {
            //Console.WriteLine("One Time Set Up - перед раном тестов");
        }

        public void GlobalOneTimeTearDown()
        {
            //Console.WriteLine("One Time Tear Down - после рана тестов");
        }
    }
}
