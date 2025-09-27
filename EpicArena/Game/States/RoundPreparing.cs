using TimeToBeEpic.Game.Constants;
using TimeToBeEpic.Game.Logic;
using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game.States
{
    class RoundPreparing(IGameContextData gameData, StateMachine stateMachine) : GameState(gameData, stateMachine)
    {
        private readonly Event _event = new();

        private Hero? _hero;
        private Enemy? _enemy;

        private bool _isPlayerFirst;

        public override void OnEnter()
        {
            _hero = _gameData.Hero;
            _enemy = _gameData.CurrentEnemy;
        }

        public override void DoStep()
        {
            _gameData.NewRound();

            _hero.StartNewRound();

            _enemy.Init(GetRandomEnemyType());
            
            _isPlayerFirst = isPlayerStepFirstly();

            if (_isPlayerFirst)
                _stateMachine.SetStatePlayerTurn();
            else
                _stateMachine.SetStateEnemyTurn();

            _event.Call(DebugEvent.OnRoundPreparing, _hero, _enemy);

            Console.Clear();

            _UI?.ShowStartFightScreen(_hero, _enemy, _isPlayerFirst, _gameData.Round);

            _stateMachine.DoStep();
        }

        private bool isPlayerStepFirstly()
        {
            return _hero.Agility >= _enemy.Agility ? true : false;
        }

        private EnemyType GetRandomEnemyType()
        {
            var values = Enum.GetValues(typeof(EnemyType));
            return (EnemyType)values.GetValue(Random.Shared.Next(values.Length));
        }
    }
}
