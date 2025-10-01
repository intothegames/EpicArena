using EpicArena.Game.Constants;
using EpicArena.Game.Services;

namespace EpicArena.Game.Logic
{
    public enum EnemyType
    {
        Goblin,
        Skeleton,
        Slime,
        Ghost,
        Golem,
        Dragon
    }

    public class Enemy : Unit
    {
        public ILootable Loot { get; private set; }
        public EnemyType Type { get; private set; }

        public void Init(EnemyType type)
        {
            IsAlive = true;

            var stats = EnemyClass.GetStats(type);

            Type = type;
            MaxHealth = stats.Health;

            IsPoisoned = false;
            _poisonDamage = 0;

            Turn = 0;

            Strength = stats.ClassUnitStats[StatsType.Strength];
            Agility = stats.ClassUnitStats[StatsType.Agility];
            Stamina = stats.ClassUnitStats[StatsType.Stamina];

            CurrentWeapon = stats.ClassWeapon;
            Loot = stats.ClassLoot;

            if (stats.ClassAbility != null)
            {
                UnitAbilities = stats.ClassAbility;
            }
            else
            {
                UnitAbilities.Clear();
            }

            _event.Call(DebugEvent.OnEnemy, Type, MaxHealth);
        }
    }
}