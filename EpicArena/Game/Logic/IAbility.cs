using EpicArena.Game.Constants;

namespace EpicArena.Game.Logic 
{
    public interface IAbility { }

    public interface IAttackAbility : IAbility
    {
        int ApplyAttackModifier(Unit attacker, Unit defender, int incomingDamage);
    }

    public interface IDefendAbility : IAbility
    {
        int ApplyDefendModifier(Unit attacker, Unit defender, int incomingDamage);
    }

    public interface IPermanentAbility : IAbility
    {
        Dictionary<StatsType, int> StatsToInkrease {  get; }
    }

    public class SneakAttack : IAttackAbility
    {
        // +1 к урону если ловкость персонажа выше ловкости цели
        public int ApplyAttackModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = attacker.Agility > defender.Agility ? 
                incomingDamage + Values.SNEAK_ATTACK_DAMAGE : incomingDamage;

            return outcomingDamage;
        }
    }

    public class ImpulseToAct : IAttackAbility
    {
        // В первый ход наносит двойной урон оружием
        public int ApplyAttackModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = attacker.Turn == Values.IMPULSE_TO_ACT_TURN ?
                incomingDamage + attacker.CurrentWeapon.Damage * Values.IMPULSE_TO_ACT_MULTIPLY_DAMAGE_COUNT : incomingDamage;

            return outcomingDamage;
        }
    }
    public class Rage : IAttackAbility
    {
        // +2 к урону в первые 3 хода, потом -1 к урону
        public int ApplyAttackModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = attacker.Turn <= Values.RAGE_DURATION ?
                incomingDamage + Values.RAGE_INCREASE_DAMAGE : incomingDamage - Values.RAGE_REDUCTION_DAMAGE;

            return outcomingDamage;
        }
    }

    public class AgilityBoost : IPermanentAbility
    {
        // Ловкость +1
        public Dictionary<StatsType, int> StatsToInkrease { get; private set; }

        public AgilityBoost()
        {
            StatsToInkrease = new Dictionary<StatsType, int>
            {
                [StatsType.Agility] = Values.AGILITY_BOOST_AGILITY_VALUE,
            };
        }
    }

    public class Shield : IDefendAbility
    {
        // -3 к получаемому урону если сила персонажа выше силы атакующего
        public int ApplyDefendModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = defender.Strength > attacker.Strength ?
                incomingDamage - Values.SHIELD_REDUCTION_DAMAGE : incomingDamage;

            return outcomingDamage;
        }
    }

    public class StoneSkin : IDefendAbility
    {
        // Получаемый урон снижается на значение выносливости
        public int ApplyDefendModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = incomingDamage - defender.Stamina;
            
            return outcomingDamage;
        }
    }

    public class Poison : IAttackAbility
    {
        // Наносит дополнительные +1 урона на втором ходу, +2 на третьем и так далее.
        public int ApplyAttackModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            //int outcomingDamage = attacker.Turn - Values.POISON_START_TURN > 0 ?
            //    (attacker.Turn - Values.POISON_START_TURN) * Values.POISON_DAMAGE + incomingDamage : incomingDamage;
            defender.IsPoisoned = true;

            return incomingDamage;
        }
    }

    public class StrengthBoost : IPermanentAbility
    {
        // Сила +1
        public Dictionary<StatsType, int> StatsToInkrease { get; private set; }

        public StrengthBoost()
        {
            StatsToInkrease = new Dictionary<StatsType, int>
            {
                [StatsType.Strength] = Values.STRENGTH_BOOST_STRENGTH_VALUE,
            };
        }
    }

    public class StaminaBoost : IPermanentAbility
    {
        // Выносливость +1
        public Dictionary<StatsType, int> StatsToInkrease { get; private set; }

        public StaminaBoost()
        {
            StatsToInkrease = new Dictionary<StatsType, int>
            {
                [StatsType.Stamina] = Values.STAMINA_BOOST_STAMINA_VALUE,
            };
        }
    }

    // Enemy
    public class SkeletonWeakness : IDefendAbility
    {
        // Получает вдвое больше урона, если его бьют дробящим оружием
        public int ApplyDefendModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = attacker.CurrentWeapon.TypeOfWeapon == WeaponType.Crushing ?
                incomingDamage * Values.SKELETON_WEAKNESS_MULTIPLY_DAMAGE : incomingDamage;

            return outcomingDamage;
        }
    }

    public class SlimeImmunity : IDefendAbility
    {
        // Рубящее оружие не наносит ему урона (но урон от силы и прочих особенностей, даже "порыва к действию" воина, работает)
        public int ApplyDefendModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = attacker.CurrentWeapon.TypeOfWeapon == WeaponType.Chopping ?
                incomingDamage - attacker.CurrentWeapon.Damage : incomingDamage;

            return outcomingDamage;
        }
    }

    public class DragonBreath : IAttackAbility
    {
        // Каждый 3-й ход дышит огнём, нанося дополнительно 3 урона
        public int ApplyAttackModifier(Unit attacker, Unit defender, int incomingDamage)
        {
            int outcomingDamage = attacker.Turn % Values.DRAGON_BREATH_TURN_TO_ACTIVATE == 0 ?
                incomingDamage + Values.DRAGON_BREATH_INCREASE_DAMAGE : incomingDamage;

            return outcomingDamage;
        }
    }
}