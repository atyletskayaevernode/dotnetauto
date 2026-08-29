using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Modules;

namespace Tests1.Preconditions
{
    public class NotificationPreconditions
    {
        public ServiceProvider Provider { get; }

        public NotificationPreconditions()
        {
            var services = new ServiceCollection();
            services.AddNotifications();
            Provider = services.BuildServiceProvider();
        }
    }
}
