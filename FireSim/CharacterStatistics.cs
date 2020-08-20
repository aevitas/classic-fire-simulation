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

        // https://classic.wowhead.com/gear-planner/mage/troll/AjwAgUuvXmQCVGiDS6pfZYVTX045BljKh1PVXmQIU2CJUsJOKIpUUWH2C1TNDFVMDUuzDkuLD1jLkFR2WN0RVF0SVGM
        public static CharacterStatistics BestInSlotUnbuffed => new CharacterStatistics
        {
            Name = "Best In Slot (Unbuffed)",
            CriticalStrikeChance = 14.02 + 6,
            HitChance = 10 + 6,
            SpellDamage = 660
        };

        public static CharacterStatistics BestInSlot => new CharacterStatistics
        {
            Name = "Best In Slot",
            CriticalStrikeChance = 14.02 + 6,
            HitChance = 10 + 6,
            SpellDamage = 660,
            ConsumableSpellPower = 35 + 40,
            WorldBuffCriticalStrikeChance = WorldBuffs.DragonSlayerCriticalStrikeChance +
                                            WorldBuffs.SongflowerCriticalStrikeChance + WorldBuffs.DireMaulCritChance +
                                            WorldBuffs.ZulGurubCritChance
        };

        public static CharacterStatistics BestInSlotFlasked => new CharacterStatistics
        {
            Name = "Best In Slot (Flasked)",
            CriticalStrikeChance = 14.02 + 6,
            HitChance = 10 + 6,
            SpellDamage = 660,
            ConsumableSpellPower = 35 + 40 + 150,
            WorldBuffCriticalStrikeChance = WorldBuffs.DragonSlayerCriticalStrikeChance +
                                            WorldBuffs.SongflowerCriticalStrikeChance + WorldBuffs.DireMaulCritChance +
                                            WorldBuffs.ZulGurubCritChance
        };

        // https://classic.wowhead.com/gear-planner/mage/troll/AjwAgUISXmQCVGiDQhVfZYVCFE45BkGyh0ITXmQIQhCJQhZOKIpCEWH2C1TNDEvLDUuzDkuLD1jLkFR2WN0RVF0SVGM
        public static CharacterStatistics TierTwoUnbuffed => new CharacterStatistics
        {
            Name = "Tier 2 (Unbuffed) - Forced Concentration",
            CriticalStrikeChance = 12.71,
            HitChance = 8 + 6,
            SpellDamage = 582
        };

        public static CharacterStatistics TierTwo => new CharacterStatistics
        {
            Name = "Tier 2 - Forced Concentration",
            CriticalStrikeChance = 12.71,
            HitChance = 8 + 6,
            SpellDamage = 582,
            ConsumableSpellPower = 35 + 40,
            WorldBuffCriticalStrikeChance = WorldBuffs.DragonSlayerCriticalStrikeChance +
                                            WorldBuffs.SongflowerCriticalStrikeChance + WorldBuffs.DireMaulCritChance +
                                            WorldBuffs.ZulGurubCritChance
        };

        public static CharacterStatistics TierTwoFlasked => new CharacterStatistics
        {
            Name = "Tier 2 - Forced Concentration (Flasked)",
            CriticalStrikeChance = 12.71,
            HitChance = 8 + 6,
            SpellDamage = 582,
            ConsumableSpellPower = 35 + 40 + 150,
            WorldBuffCriticalStrikeChance = WorldBuffs.DragonSlayerCriticalStrikeChance +
                                            WorldBuffs.SongflowerCriticalStrikeChance + WorldBuffs.DireMaulCritChance +
                                            WorldBuffs.ZulGurubCritChance
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