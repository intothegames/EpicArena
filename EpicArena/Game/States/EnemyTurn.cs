using TimeToBeEpic.Game.Logic;
using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game.States
{
    class EnemyTurn(IGameContextData data, StateMachine stateMachine) : GameState(data, stateMachine)
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
            _event.Call(DebugEvent.OnEnemyTurn);

            if (_enemy.IsHit(_hero))
            {
                _damage = _enemy.Attack(_hero, _damageCalculator);
                _UI.ShowEnemyAttack(_hero, _damage, _enemy);
            }
            else
            {
                _UI.ShowEnemyMiss(_hero, _enemy);
            }

            if (_hero.IsAlive)
            {
                _stateMachine.SetStatePlayerTurn();
            }
            else
            {
                _stateMachine.SetStateRoundDefeat();
            }

            _stateMachine.DoStep();
        }
    }
}