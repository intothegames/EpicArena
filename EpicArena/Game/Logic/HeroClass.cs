using EpicArena.Game.Constants;

namespace EpicArena.Game.Logic
{
    public abstract class HeroClass
    {
        public abstract HeroStats Stats { get; }
    }

    class Rogue : HeroClass
    {
        public override HeroStats Stats => Values.ROGUE_STATS;
    }

    class Warrior : HeroClass
    {
        public override HeroStats Stats => Values.WARRIOR_STATS;
    }

    class Barbarian : HeroClass
    {
        public override HeroStats Stats => Values.BARBARIAN_STATS;
    }
}
