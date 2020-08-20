using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FireSim
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceProvider();

            var sim = services.GetRequiredService<Simulator>();

            sim.RunSimulation(new Simulation
            {
                Character = CharacterStatistics.BestInSlot,
                FireballCount = 25,
                Iterations = 100000
            });

            sim.RunSimulation(new Simulation
            {
                Character = CharacterStatistics.BestInSlotUnbuffed,
                FireballCount = 25,
                Iterations = 100000
            });

            sim.RunSimulation(new Simulation
            {
                Character = CharacterStatistics.TierTwo,
                FireballCount = 27, // Roughly a 10% proc chance on T2
                Iterations = 100000
            });


            sim.RunSimulation(new Simulation
            {
                Character = CharacterStatistics.TierTwoUnbuffed,
                FireballCount = 27, // Roughly a 10% proc chance on T2
                Iterations = 100000
            });

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
