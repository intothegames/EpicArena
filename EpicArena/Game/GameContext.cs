using TimeToBeEpic.Game.Logic;
using TimeToBeEpic.Game.Services;
using TimeToBeEpic.Game.States;

namespace TimeToBeEpic.Game
{
    class GameContext : IGameContextData
    {
        private readonly StateMachine _stateMachine;

        public GameContext()
        {
            Services = new GameServices();

            _stateMachine = new StateMachine(this);

            Hero = new Hero();
            CurrentEnemy = new Enemy();
        }

        public GameServices Services { get; private set; }

        public Hero Hero { get; private set; }
        public Enemy CurrentEnemy { get; private set; }

        public int Round { get; private set; } = 0;

        public void StartGame()
        {
            _stateMachine.InitStates();
            _stateMachine.SetStateByDefault();
            _stateMachine.DoStep();
        }

        public void NewRound()
        {
            Round++;
        }

        public void ResetRounds()
        {
            Round = 0;
        }
    }
}
