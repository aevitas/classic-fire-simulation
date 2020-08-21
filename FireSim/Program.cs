using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FireSim
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceProvider();
            var configuration = new ConfigurationBuilder().AddJsonFile("simulations.json").Build();

            var simulations = configuration.GetSection("Simulations").Get<List<Simulation>>();
            var simulator = services.GetRequiredService<Simulator>();

            foreach (var s in simulations)
                simulator.RunSimulation(s);

            Console.ReadLine();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddLogging(opts =>
            {
                opts.AddConsole();
                //opts.SetMinimumLevel(LogLevel.Debug);
            });

            services.AddTransient<Simulator>();

            return services.BuildServiceProvider();
        }
    }
}
