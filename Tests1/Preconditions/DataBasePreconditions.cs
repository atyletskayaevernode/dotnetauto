using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Modules;

namespace Tests1.Preconditions
{
    public class DataBasePreconditions
    {
        public ServiceProvider Provider {  get; }

        public DataBasePreconditions() 
        {
            var services = new ServiceCollection();
            services.AddDataAccessMarketplace("Data Source=marketplace.db");
            Provider = services.BuildServiceProvider();
        }
    }
}
