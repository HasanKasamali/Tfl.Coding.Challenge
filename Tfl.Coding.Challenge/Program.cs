using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Tfl.Coding.Challenge.Infrastructure;

namespace Tfl.Coding.Challenge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            try
            {
                var serviceReference = serviceProvider.GetService<ITflApi>();
                var data = await serviceReference.Status(args[0], default);
                Console.WriteLine(data.SuccessCode != "OK" ? $"{data.Id} is not a valid road" : $"The status of road {data.Id} is as follows");

                if (data?.SuccessCode == "OK")
                {
                    Console.WriteLine($"Road Status {data?.RoadStatus}");
                    Console.WriteLine($"Road Status Description {data?.RoadStatusDescription}");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            var config = LoadConfiguration();
            serviceCollection.AddSingleton(config);
            serviceCollection.AddTransient<ITflApi, TflApi>();

            return serviceCollection;
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
