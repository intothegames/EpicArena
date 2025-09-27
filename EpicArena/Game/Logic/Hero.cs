using TimeToBeEpic.Game.Constants;
using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game.Logic
{
    public class Hero : Unit
    {
        private Event _event = new Event();

        public int Level { get; private set; } = 0;
        public List<HeroClass> HeroClasses { get; private set; } = new List<HeroClass>();

        public void InitHero(HeroClass heroClass, UnitStats stats)
        {
            ResetHero();
            InitStats(stats);
            LevelUp(heroClass);
        }

        public void LevelUp(HeroClass newHeroClass)
        {
            HeroClasses.Add(newHeroClass);

            int newHeroClassLevel = HeroClasses.Count(h => h.GetType() == newHeroClass.GetType());
            IAbility newAbility = newHeroClass.stats.ClassAbility[newHeroClassLevel - 1];
            UnitAbilities.Add(newAbility);

            if (newAbility is IPermanentAbility permanentAbility)
                ApplyPermanentAbility(permanentAbility.StatsToInkrease);

            if(Level == 0)
                CurrentWeapon = newHeroClass.stats.ClassWeapon;

            MaxHealth += newHeroClass.stats.HealthLevelInkrease;

            Level++;

            _event.Call(DebugEvent.OnHero_LevelUp, newHeroClass.GetType().Name, MaxHealth);
        }

        public void SetWeapon(Weapon newWeapon)
        {
            _event.Call(DebugEvent.OnHero_SetWeapon, CurrentWeapon.GetType().Name, newWeapon.GetType().Name);
            CurrentWeapon = newWeapon;
        }

        private void ResetHero()
        {
            IsAlive = true;

            MaxHealth = 0;
            Level = 0;
            Turn = 0;

            HeroClasses.Clear();
            UnitAbilities.Clear();
        }

        public void StartNewRound()
        {
            Turn = 0;
            Health = MaxHealth;
        }

        private void InitStats(UnitStats stats)
        {
            Strength = stats[StatsType.Strength];
            Agility = stats[StatsType.Agility];
            Stamina = stats[StatsType.Stamina];

            HeroClasses = new List<HeroClass>();
        }

        private void ApplyPermanentAbility(Dictionary<StatsType, int> StatsToInkrease)
        {
            foreach (var kvp in StatsToInkrease)
            {
                switch (kvp.Key)
                {
                    case StatsType.Strength:
                        //DEBUG.PrintOutput($"{kvp.Key}: +{kvp.Value}");
                        _event.Call(DebugEvent.OnHero_ApplyPermanentAbility, kvp.Key, kvp.Value);
                        Strength += kvp.Value;
                        break;
                    case StatsType.Agility:
                        _event.Call(DebugEvent.OnHero_ApplyPermanentAbility, kvp.Key, kvp.Value);
                        Agility += kvp.Value;
                        break;
                    case StatsType.Stamina:
                        _event.Call(DebugEvent.OnHero_ApplyPermanentAbility, kvp.Key, kvp.Value);
                        Stamina += kvp.Value;
                        break;
                    default:
                        throw new Exception($"Invalid Stat: {kvp.Key}");
                }
            }
        }
    }
}