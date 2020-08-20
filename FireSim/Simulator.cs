using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace FireSim
{
    public class Simulator
    {
        private readonly ILogger<Simulator> _logger;
        private const int BaseFireballDamage = (596 + 760) / 2;

        public Simulator(ILogger<Simulator> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void RunSimulation(Simulation simulation)
        {
            if (simulation == null)
                throw new ArgumentNullException(nameof(simulation));

            Console.WriteLine($"-- Start of Simulation for {simulation.Character.Name} -- ");

            Console.WriteLine(
                $"Running simulation of {simulation.Iterations} iteration(s) with {simulation.FireballCount} fireballs.");
            Console.WriteLine($"{simulation.Character}");

            List<IterationResult> results = new List<IterationResult>();
            for (int i = 0; i < simulation.Iterations; i++)
                results.Add(RunIteration(simulation));

            Console.WriteLine($"Average damage: {results.Select(r => r.Damage).Average()}");

            var highRoll = results.OrderByDescending(r => r.Damage).First();
            Console.WriteLine(
                $"Highest roll: {highRoll.Damage} ({highRoll.CriticalStrikes} crits, {highRoll.Misses} misses)");

            var lowRoll = results.OrderBy(r => r.Damage).First();
            Console.WriteLine(
                $"Lowest roll: {lowRoll.Damage} ({lowRoll.CriticalStrikes} crits, {lowRoll.Misses} misses)");

            Console.WriteLine($"-- End of Simulation for {simulation.Character.Name} -- \n\n");
        }

        private IterationResult RunIteration(Simulation simulation)
        {
            var result = new IterationResult();
            var rng = new Random();
            var isHitCapped = simulation.Character.HitChance >= 16;
            var missChance = isHitCapped ? 1 : 16 - simulation.Character.HitChance;

            var totalCritChance = simulation.Character.CriticalStrikeChance +
                                  simulation.Character.WorldBuffCriticalStrikeChance;

            var totalSpellDamage =
                simulation.Character.SpellDamage + simulation.Character.WorldBuffCriticalStrikeChance;

            for (int i = 0; i < simulation.FireballCount; i++)
            {
                var critRoll = rng.Next(0, 100);
                var missRoll = rng.Next(0, 100);

                bool isCrit = critRoll <= totalCritChance;
                bool isMiss = missRoll <= missChance;

                if (isMiss)
                {
                    result.Misses++;
                    continue;
                }

                if (isCrit)
                    result.CriticalStrikes++;

                var damage = isCrit
                    ? (BaseFireballDamage + totalSpellDamage) * 2
                    : BaseFireballDamage + totalSpellDamage;

                result.Damage += damage;
            }

            return result;
        }
    }
}
