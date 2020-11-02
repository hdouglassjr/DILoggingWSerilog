using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello from console app.");

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get an instance of the service library
            var myService = serviceProvider.GetService<MyNetServiceLib.MyService>();

            // Call the service, logs are made here
            myService.DoSomething("My param passed in");

            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(config => { config.AddSerilog(); })
                .AddTransient<MyNetServiceLib.MyService>();
        }
    }
}