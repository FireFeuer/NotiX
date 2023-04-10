using Microsoft.Extensions.DependencyInjection;
using NotiX7.Services;
using NotiX7.ViewModels;

namespace NotiX7
{
    internal class ServicesLocator
    {
        public static ServiceProvider provider;

        public static void Init()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<NoteService>();
            services.AddTransient<ColorService>();

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
