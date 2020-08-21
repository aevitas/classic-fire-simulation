using System.Text;

namespace FireSim
{
    public struct CharacterStatistics
    {
        public string Name { get; set; }

        public double CriticalStrikeChance { get; set; }

        public double HitChance { get; set; }

        public int SpellDamage { get; set; }

        public int ConsumableSpellPower { get; set; }

        public int WorldBuffCriticalStrikeChance { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Critical Strike: {CriticalStrikeChance}");
            sb.AppendLine($"Hit: {HitChance}");
            sb.AppendLine($"Spell Damage: {SpellDamage}");
            sb.AppendLine($"Consumable Spell Damage: {ConsumableSpellPower}");
            sb.AppendLine($"World Buff Crit: {WorldBuffCriticalStrikeChance}");

            return sb.ToString();
        }
    }
}