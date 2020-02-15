using Common.Model;
using ConsoleUIHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SwApiWrapper;

namespace StarWarsTripCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            //Adding dependency injection to take care of logging
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                StarWarsConsoleUI app = serviceProvider.GetService<StarWarsConsoleUI>();
                app.Run();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<StarWarsConsoleUI>()
                .AddTransient(typeof(IWebHelper<>), typeof(WebHelper<>));
        }
    }
}
