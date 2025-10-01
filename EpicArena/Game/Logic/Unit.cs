using EpicArena.Game.Services;

namespace EpicArena.Game.Logic
{
    public abstract class Unit
    {
        protected readonly Event _event = new();

        private int _maxHealth;
        private int _stamina;
        protected int _poisonDamage = 0;

        public Unit()
        {
            UnitAbilities = new List<IAbility>();
        }

        public int MaxHealth 
        { 
            get => _maxHealth;
            protected set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");

                _maxHealth = value;
                Health = _maxHealth;
            }
        }

        public int Health { get; protected set; } = 0;

        public int Strength { get; protected set; } = 0;
        public int Agility { get; protected set; } = 0;
        public int Stamina 
        { 
            get => _stamina;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");

                _stamina = value;
                MaxHealth += _stamina;
            } 
        }

        public bool IsAlive { get; protected set; } = true;
        public bool IsPoisoned { get; set; } = false;


        public int Turn { get; protected set; } = 0;

        public Weapon CurrentWeapon { get; protected set; }
        public List<IAbility> UnitAbilities { get; protected set; }

        public int Attack(Unit target, DamageCalculator damageCalculator)
        {
            Turn++;

            int damage = damageCalculator.DamageCalculate(this, target);

            if (damage > 0)
                target.TakeDamage(damage);

            return damage;
        }

        public void TakeDamage(int damage)
        {
            _event.Call(DebugEvent.OnUnit_TakeDamage, GetType().Name, Health, damage);

            if (Health - damage <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
            else
            {
                Health -= damage;
            }
        }

        public void TakePoisonDamage()
        {
            _poisonDamage++;

            if (Health - _poisonDamage <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
            else
            {
                Health -= _poisonDamage;
            }
        }

        public bool IsHit(Unit target)
        {
            int hitChance = Random.Shared.Next(1, Agility + target.Agility + 1);

            _event.Call(DebugEvent.OnUnit_IsHit, hitChance, target.Agility);

            return hitChance > target.Agility;
        }
    }
}