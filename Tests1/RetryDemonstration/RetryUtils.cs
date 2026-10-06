using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; // <-- added

namespace Tests1.RetryDemonstration
{
    public class RetryUtils
    {
        public delegate bool Operation();

        public static void Retry(int maxRetries, Operation operation)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                Console.WriteLine(@$"Attempt {attempt} of {maxRetries}");
                if (operation())
                {
                    Console.WriteLine("Operation succeeded.");
                    return; //механизм выхода из метода при успехе, на деле ничего не возвращаем
                }
            }
            
            throw new Exception($"Operation failed after maximum retries ({maxRetries}).");
        }

        public static bool RetryWithReturnValue(int maxRetries, Operation operation)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                Console.WriteLine(@$"Attempt {attempt} of {maxRetries}");
                if (operation())
                {
                    Console.WriteLine("Operation succeeded.");
                    return true;
                }
            }

            return false; // Return false if the operation failed after maximum retries
        }

        public void RetryWithTimeout(Operation operation, int timeoutMs, int delayMs)
        {
            var startTime = DateTime.Now;

            for (int attempt = 1; ; attempt++)
            {
                Console.WriteLine(@$"Attempt {attempt} at {DateTime.Now}");

                if (operation())
                {
                    return;
                }

                if((DateTime.Now - startTime).TotalMilliseconds > timeoutMs)
                {
                    throw new TimeoutException($"Operation did not succeed within the timeout of {timeoutMs} ms.");
                }

                Thread.Sleep(delayMs);
            }
        }
    }
}
