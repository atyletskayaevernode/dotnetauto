using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.RetryDemonstration
{
    public class AdditionalMethods
    {
        public static bool RandomSuccess()
        {
            var rnd = new Random();
            bool result = rnd.Next(0, 10) == 1;
            Console.WriteLine($"result = {result}");
            return result;
        }
    }
}
