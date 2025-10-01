using EpicArena.Game.Logic;
using EpicArena.Game.Services;

namespace EpicArena.Game.States
{
    class PlayerTurn(IGameContextData data, StateMachine stateMachine) : GameState(data, stateMachine)
    {
        private readonly Event _event = new();

        private DamageCalculator? _damageCalculator;

        private Hero _hero;
        private Enemy _enemy;

        private int _damage;

        public override void OnEnter()
        {
            _damageCalculator = (DamageCalculator?)_gameData.Services.GetService<DamageCalculator>();

            _hero = _gameData.Hero;
            _enemy = _gameData.CurrentEnemy;
        }

        public override void DoStep()
        {
            _event.Call(DebugEvent.OnPlayerTurn);

            if (_enemy.IsPoisoned)
            {
                _enemy.TakePoisonDamage();
            }

            if (_hero.IsHit(_enemy))
            {
                _damage = _hero.Attack(_enemy, _damageCalculator);
                _UI.ShowHeroAttack(_hero, _damage, _enemy);
            }
            else
            {
                _UI.ShowHeroMiss(_hero, _enemy);
            }

            if (_enemy.IsAlive)
            {
                _stateMachine.SetStateEnemyTurn();
            }
            else
            {
                _stateMachine.SetStateRoundWin();
            }

            _stateMachine.DoStep();
        }
    }
}