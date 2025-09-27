using TimeToBeEpic.Game.Constants;
using TimeToBeEpic.Game.Logic;

namespace TimeToBeEpic.Game.Services
{
    public class DamageCalculator : IGameService
    {
        private Event _event = new Event();
        public int DamageCalculate(Unit attacker, Unit defender)
        {
            int damage = CalculateAttackerDamage(attacker, defender);
            damage = CalculateAttackerAbilities(attacker, defender, damage);
            damage = CalculateDefenderAbilities(attacker, defender, damage);

            return damage;
        }

        private int CalculateAttackerDamage(Unit attacker, Unit defender)
        {
            int damage = attacker.CurrentWeapon.Damage + attacker.Strength;
            _event.Call(DebugEvent.OnDamageCalculator_CalculateAttackerDamage, attacker.GetType().Name, damage);

            return damage;
        }

        private int CalculateAttackerAbilities(Unit attacker, Unit defender, int damage)
        {
            // damage += attacker.UnitAbilities.OfType<IAttackAbility>().Sum(a => a.ApplyAttackModifier(attacker, defender, damage));
            int newDamage = damage;

            foreach (var ability in attacker.UnitAbilities)
            {
                if (ability is IAttackAbility attackAbility)
                {
                    newDamage = attackAbility.ApplyAttackModifier(attacker, defender, newDamage);
                    _event.Call(DebugEvent.OnDamageCalculator_CalculateAttackerAbilities, attacker.GetType().Name, attackAbility.GetType().Name, damage, newDamage);
                }
            }

            return newDamage;
        }

        private int CalculateDefenderAbilities(Unit attacker, Unit defender, int damage)
        {
            // damage += defender.UnitAbilities.OfType<IDefendAbility>().Sum(d => d.ApplyDefendModifier(attacker, defender, damage));
            int newDamage = damage;

            foreach (var ability in defender.UnitAbilities)
            {
                if (ability is IDefendAbility defendAbility)
                {
                    newDamage = defendAbility.ApplyDefendModifier(attacker, defender, newDamage);
                    _event.Call(DebugEvent.OnDamageCalculator_CalculateDefenderAbilities, defender.GetType().Name, defendAbility.GetType().Name, damage, newDamage);
                }
            }

            newDamage = newDamage > 0 ? newDamage : 0;

            return newDamage;
        }
    }
}
