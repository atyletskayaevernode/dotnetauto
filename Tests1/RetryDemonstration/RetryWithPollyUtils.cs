using System;
using System.Collections.Generic;
using System.Text;
using Polly;
using Polly.Timeout;

namespace Tests1.RetryDemonstration
{
    public class RetryWithPollyUtils
    {
        public delegate bool Operation();

        public static void RetryWithTimeout(Operation operation, int timeoutMs, int delayMs)
        {
            // правило повторных попыткок с использованием Polly
            var retryPolicy = Policy
                .HandleResult<bool>(result => !result)
                .WaitAndRetry(
                retryCount: int.MaxValue,
                sleepDurationProvider: _ => TimeSpan.FromMilliseconds(delayMs),
                onRetry: (outcome, timespan, attempt, context) =>
                {
                    Console.WriteLine($"{DateTime.Now} attempt {attempt}");
                });

            //правила для времени
            var timeoutPolicy = Policy.Timeout(
                TimeSpan.FromMilliseconds(timeoutMs), TimeoutStrategy.Optimistic);

            timeoutPolicy.Wrap(retryPolicy).Execute(() =>
            {
                return operation();
            });
        }
    }
}
