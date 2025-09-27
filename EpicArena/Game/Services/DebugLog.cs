using System.Diagnostics;
using TimeToBeEpic.Game.Constants;
using TimeToBeEpic.Game.Logic;

namespace TimeToBeEpic.Game.Services
{
    public enum DebugEvent
    {
        OnMainMenu,
        OnRoundPreparing,
        OnPlayerTurn,
        OnEnemyTurn,
        OnRoundWin,
        OnRoundDefeat,
        OnHero_LevelUp,
        OnHero_SetWeapon,
        OnHero_ApplyPermanentAbility,
        OnEnemy,
        OnUnit_TakeDamage,
        OnUnit_IsHit,
        OnDamageCalculator_CalculateAttackerDamage,
        OnDamageCalculator_CalculateAttackerAbilities,
        OnDamageCalculator_CalculateDefenderAbilities
    }

    public class DebugLog : IGameService
    {
        private EventListener _listener = new EventListener();
        private static bool isDebugOn = Settings.IsDebugEnabled;

        public DebugLog()
        {
            _listener.Add(DebugEvent.OnMainMenu, OnMainMenu);
            _listener.Add(DebugEvent.OnRoundPreparing, OnRoundPreparing);
            _listener.Add(DebugEvent.OnPlayerTurn, OnPlayerTurn);
            _listener.Add(DebugEvent.OnEnemyTurn, OnEnemyTurn);
            _listener.Add(DebugEvent.OnRoundWin, OnRoundWin);
            _listener.Add(DebugEvent.OnRoundDefeat, OnRoundDefeat);

            _listener.Add(DebugEvent.OnHero_LevelUp, OnHero_LevelUp);
            _listener.Add(DebugEvent.OnHero_SetWeapon, OnHero_SetWeapon);
            _listener.Add(DebugEvent.OnHero_ApplyPermanentAbility, OnHero_ApplyPermanentAbility);
            _listener.Add(DebugEvent.OnEnemy, OnEnemy);
            _listener.Add(DebugEvent.OnUnit_TakeDamage, OnUnit_TakeDamage); 
            _listener.Add(DebugEvent.OnUnit_IsHit, OnUnit_IsHit);

            _listener.Add(DebugEvent.OnDamageCalculator_CalculateAttackerDamage, OnDamageCalculator_CalculateAttackerDamage);
            _listener.Add(DebugEvent.OnDamageCalculator_CalculateAttackerAbilities, OnDamageCalculator_CalculateAttackerAbilities);
            _listener.Add(DebugEvent.OnDamageCalculator_CalculateDefenderAbilities, OnDamageCalculator_CalculateDefenderAbilities);
        }

        private void OnMainMenu(UnitStats stats)
        {
            PrintOutput("\n== MainMenu ==");
            PrintOutput($"- random Strength: {stats[StatsType.Strength]}");
            PrintOutput($"- random Agility: {stats[StatsType.Agility]}");
            PrintOutput($"- random Stamina: {stats[StatsType.Stamina]}");
        }

        private void OnRoundPreparing(Hero hero, Enemy enemy)
        {
            PrintOutput("\n== RoundPreparing ==");
            PrintOutput($"Hero weapon: {hero.CurrentWeapon.GetType().Name}");
            PrintOutput($"Enemy: {enemy.Type}");
            PrintOutput($"Hero.Agility: {hero.Agility.ToString()}");
            PrintOutput($"Enemy.Agility: {enemy.Agility.ToString()}");
        }

        private void OnPlayerTurn()
        {
            PrintOutput("\n== PlayerTurn ==");
        }

        private void OnEnemyTurn()
        {
            PrintOutput("\n== EnemyTurn ==");
        }

        private void OnRoundWin(int round)
        {
            PrintOutput("\n== RoundWin ==");
            PrintOutput($"Rounds win: {round}");
        }

        private void OnRoundDefeat()
        {
            PrintOutput("\n== RoundDefeat ==");
        }

        private void OnHero_LevelUp(string newClass, int maxHealth)
        {
            PrintOutput($"New class: {newClass}, MaxHeals: {maxHealth}");
        }

        private void OnHero_SetWeapon(string currentWeapon, string newWeapon)
        {
            PrintOutput($"Change: {currentWeapon} -> {newWeapon}");
        }

        private void OnHero_ApplyPermanentAbility(StatsType key, int value)
        {
            PrintOutput($"{key}: +{value}");
        }

        private void OnEnemy(EnemyType type, int maxHealth)
        {
            PrintOutput($"{type} - MaxHealth: {maxHealth}");
        }

        private void OnUnit_TakeDamage(string defender, int health, int damage)
        {
            PrintOutput($"{defender} take damage: {health} hp - {damage} dmg");
        }

        private void OnUnit_IsHit(int hitChance, int targetAgility)
        {
            PrintOutput($"Hit Chance: {hitChance}, target Agility: {targetAgility}");
        }

        private void OnDamageCalculator_CalculateAttackerDamage(string attacker, int damage)
        {
            PrintOutput($"{attacker} standart damage: {damage}");
        }
        private void OnDamageCalculator_CalculateAttackerAbilities(string attacker, string attackAbility, int damage, int newDamage)
        {
            PrintOutput($"{attacker} apply {attackAbility}: {damage} -> {newDamage}");
        }
        private void OnDamageCalculator_CalculateDefenderAbilities(string defender, string defendAbility, int damage, int newDamage)
        {
            PrintOutput($"{defender} apply {defendAbility}: {damage} -> {newDamage}");
        }

        private void PrintOutput(string message)
        {
            if (isDebugOn)
            {
                Debug.WriteLine(message);
            }
        }
    }
}
