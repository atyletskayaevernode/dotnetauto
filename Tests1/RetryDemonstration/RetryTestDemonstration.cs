using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.RetryDemonstration
{
    [TestFixture]
    public class RetryTestDemonstration
    {
        [Test]
        public void TestWithRandomSuccess()
        {
            RetryUtils.Operation operation = AdditionalMethods.RandomSuccess;
            RetryUtils.Retry(5, operation);
        }

        [Test]
        public void TestWithRandomSuccessWithReturnValue()
        {
            RetryUtils.Operation operation = AdditionalMethods.RandomSuccess;
            var result = RetryUtils.RetryWithReturnValue(5, operation);
            Assert.That(result, Is.True, "Operation failed after maximum retries.");
        }

        [Test]
        public void TestWithRandomSuccessWithTimeout()
        {
            RetryUtils.Operation operation = AdditionalMethods.RandomSuccess;
            // RetryUtils.RetryWithTimeout(operation, 50000, 1000);
            var retryUtils = new RetryUtils();
            retryUtils.RetryWithTimeout(operation, 50000, 1000);
        }

        [Test]
        public void RetryWithPolly()
        {
            RetryWithPollyUtils.Operation operation = AdditionalMethods.RandomSuccess;
            RetryWithPollyUtils.RetryWithTimeout(operation, 60000, 2000);
        }
    }
}
