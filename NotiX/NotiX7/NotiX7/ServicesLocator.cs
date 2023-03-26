using Microsoft.Extensions.DependencyInjection;
using NotiX7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiX7
{
    internal class ServicesLocator
    {
        public static ServiceProvider provider;

        public static void Init()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<WindowViewModel>();
           
            provider = services.BuildServiceProvider();
            foreach (var service in services)
            {
                provider.GetRequiredService(service.ServiceType);
            }

        }
       
        public WindowViewModel WindowViewModel => provider.GetRequiredService<WindowViewModel>();
    }
}
