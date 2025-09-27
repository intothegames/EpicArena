using TimeToBeEpic.Game.Constants;

namespace TimeToBeEpic.Game.Logic
{
    public abstract class HeroClass
    {
        public abstract HeroStats stats { get; }
    }

    class Rogue : HeroClass
    {
        public override HeroStats stats => Values.ROGUE_STATS;
    }

    class Warrior : HeroClass
    {
        public override HeroStats stats => Values.WARRIOR_STATS;
    }

    class Barbarian : HeroClass
    {
        public override HeroStats stats => Values.BARBARIAN_STATS;
    }
}
