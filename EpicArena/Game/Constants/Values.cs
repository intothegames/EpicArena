using TimeToBeEpic.Game.Logic;

namespace TimeToBeEpic.Game.Constants
{
    public static class Values
    {
        // UNITS START STATS
        public const int MIN_RANDOM_STAT_VALUE = 1;
        public const int MAX_RANDOM_STAT_VALUE = 3;
        public const int MAX_HERO_LEVEL = 3;
        public const int ROUNDS_TO_WIN = 5;

            // HERO
        public static readonly HeroStats ROGUE_STATS = new HeroStats
        {
            HealthLevelInkrease = 4,
            ClassWeapon = new Dagger(),
            ClassAbility = new List<IAbility> { new SneakAttack(), new AgilityBoost(), new Poison() }
        };

        public static readonly HeroStats WARRIOR_STATS = new HeroStats
        {
            HealthLevelInkrease = 5,
            ClassWeapon = new Sword(),
            ClassAbility = new List<IAbility> { new ImpulseToAct(), new Shield(), new StrengthBoost() }
        };

        public static readonly HeroStats BARBARIAN_STATS = new HeroStats
        {
            HealthLevelInkrease = 6,
            ClassWeapon = new Club(),
            ClassAbility = new List<IAbility> { new Rage(), new StoneSkin(), new StaminaBoost() }
        };

        // WEAPON

            // HERO
        public const WeaponType SWORD_TYPE = WeaponType.Chopping;
        public const int SWORD_DAMAGE = 3;

        public const WeaponType CLUB_TYPE = WeaponType.Crushing;
        public const int CLUB_DAMAGE = 3;

        public const WeaponType DAGGER_TYPE = WeaponType.Stabbing;
        public const int DAGGER_DAMAGE = 2;

        public const WeaponType AXE_TYPE = WeaponType.Chopping;
        public const int AXE_DAMAGE = 4;

        public const WeaponType SPEAR_TYPE = WeaponType.Stabbing;
        public const int SPEAR_DAMAGE = 3;

        public const WeaponType LEGENDARYSWORD_TYPE = WeaponType.Chopping;
        public const int LEGENDARYSWORD_DAMAGE = 10;

            // ENEMY
        public const WeaponType GOBLIN_CLAW_TYPE = WeaponType.Usual;
        public const int GOBLIN_CLAW_DAMAGE = 2;

        public const WeaponType SKELETON_JAW_TYPE = WeaponType.Usual;
        public const int SKELETON_JAW_DAMAGE = 2;

        public const WeaponType SLIME_TONGUE_TYPE = WeaponType.Usual;
        public const int SLIME_TONGUE_DAMAGE = 1;

        public const WeaponType GHOST_FINDER_TYPE = WeaponType.Usual;
        public const int GHOST_FINDER_DAMAGE = 3;

        public const WeaponType GOLEM_HAND_TYPE = WeaponType.Usual;
        public const int GOLEM_HAND_DAMAGE = 1;

        public const WeaponType DRAGON_PAW_TYPE = WeaponType.Usual;
        public const int DRAGON_PAW_DAMAGE = 4;


        // ABILITY
        public const int SNEAK_ATTACK_DAMAGE = 1;

        public const int IMPULSE_TO_ACT_TURN = 1;
        public const int IMPULSE_TO_ACT_MULTIPLY_DAMAGE_COUNT = 1;

        public const int RAGE_DURATION = 3;
        public const int RAGE_INCREASE_DAMAGE = 2;
        public const int RAGE_REDUCTION_DAMAGE = 1;

        public const int AGILITY_BOOST_AGILITY_VALUE = 1;

        public const int SHIELD_REDUCTION_DAMAGE = 3;

        //public const int POISON_DAMAGE = 1;
        //public const int POISON_START_TURN = 1;

        public const int STRENGTH_BOOST_STRENGTH_VALUE = 1;

        public const int STAMINA_BOOST_STAMINA_VALUE = 1;

        public const int SKELETON_WEAKNESS_MULTIPLY_DAMAGE = 2;

        public const int DRAGON_BREATH_TURN_TO_ACTIVATE = 3;
        public const int DRAGON_BREATH_INCREASE_DAMAGE = 3;


        // UI
        public const int IN_MILLISECONDS = 1000;
        public const int PAUSE_BETWEEN_ATTACKS = 1;
    }

    public static class EnemyClass
    {
        private static readonly Dictionary<EnemyType, EnemyStats> _stats = new()
        {
            [EnemyType.Goblin] = new EnemyStats
            {
                Health = 5,
                ClassUnitStats = new UnitStats 
                { 
                    [StatsType.Strength] = 1, 
                    [StatsType.Agility] = 1, 
                    [StatsType.Stamina] = 1 
                },
                ClassWeapon = new GoblinClaw(),
                ClassLoot = new Dagger(),
                ClassAbility = new List<IAbility>()
            },
            [EnemyType.Skeleton] = new EnemyStats
            {
                Health = 10,
                ClassUnitStats = new UnitStats 
                { 
                    [StatsType.Strength] = 2, 
                    [StatsType.Agility] = 2, 
                    [StatsType.Stamina] = 1 
                },
                ClassWeapon = new SkeletonJaw(),
                ClassLoot = new Club(),
                ClassAbility = new List<IAbility> { new SkeletonWeakness() }
            },
            [EnemyType.Slime] = new EnemyStats
            {
                Health = 8,
                ClassUnitStats = new UnitStats 
                {
                    [StatsType.Strength] = 3,
                    [StatsType.Agility] = 1,
                    [StatsType.Stamina] = 2 
                },
                ClassWeapon = new SlimeTongue(),
                ClassLoot = new Spear(),
                ClassAbility = new List<IAbility> { new SlimeImmunity() }
            },
            [EnemyType.Ghost] = new EnemyStats
            {
                Health = 6,
                ClassUnitStats = new UnitStats
                {
                    [StatsType.Strength] = 1,
                    [StatsType.Agility] = 3,
                    [StatsType.Stamina] = 1
                },
                ClassWeapon = new GhostFinger(),
                ClassLoot = new Sword(),
                ClassAbility = new List<IAbility> { new SneakAttack() }
            },
            [EnemyType.Golem] = new EnemyStats
            {
                Health = 10,
                ClassUnitStats = new UnitStats
                {
                    [StatsType.Strength] = 3,
                    [StatsType.Agility] = 1,
                    [StatsType.Stamina] = 3
                },
                ClassWeapon = new GolemHand(),
                ClassLoot = new Axe(),
                ClassAbility = new List<IAbility> { new StoneSkin() }
            },
            [EnemyType.Dragon] = new EnemyStats
            {
                Health = 20,
                ClassUnitStats = new UnitStats 
                {
                    [StatsType.Strength] = 3,
                    [StatsType.Agility] = 3,
                    [StatsType.Stamina] = 3
                },
                ClassWeapon = new DragonPaw(),
                ClassLoot = new LegendarySword(),
                ClassAbility = new List<IAbility> { new DragonBreath() }
            }
        };

        public static EnemyStats GetStats(EnemyType type) => _stats[type];
    }
}
