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

        // https://classic.wowhead.com/gear-planner/mage/troll/AjwAAUuvAlRoA0uqBVVOBljKB1PVCFNgCVLCClRRC1TNDEvLDUuLDkuzD1jLEFR2EVRdElRj
        public static CharacterStatistics BestInSlotUnbuffed => new CharacterStatistics
        {
            Name = "Best In Slot (Unbuffed)",
            CriticalStrikeChance = 11.65,
            HitChance = 10 + 6,
            SpellDamage = 543
        };

        public static CharacterStatistics BestInSlot => new CharacterStatistics
        {
            Name = "Best In Slot (Unbuffed)",
            CriticalStrikeChance = 11.65,
            HitChance = 10 + 6,
            SpellDamage = 543,
            ConsumableSpellPower = 35 + 40,
            WorldBuffCriticalStrikeChance = 5 + 5 + 3
        };

        // https://classic.wowhead.com/gear-planner/mage/troll/AjwAAUISAlRoA0IVBUIUBkGyB0ITCEIQCUIWCkIRC1TNDEvLDUuLDkuzD1jLEFR2EVRdElRj
        public static CharacterStatistics TierTwoUnbuffed => new CharacterStatistics
        {
            Name = "Tier 2 (Unbuffed)",
            CriticalStrikeChance = 11.73,
            HitChance = 6 + 6,
            SpellDamage = 474
        };

        public static CharacterStatistics TierTwo => new CharacterStatistics
        {
            Name = "Tier 2",
            CriticalStrikeChance = 11.73,
            HitChance = 6 + 6,
            SpellDamage = 474,
            ConsumableSpellPower = 35 + 40,
            WorldBuffCriticalStrikeChance = 5 + 5 + 3
        };

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