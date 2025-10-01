using EpicArena.Game.Services;

namespace EpicArena.Game.States
{
    abstract class GameState(IGameContextData gameData, StateMachine stateMachine)
    {
        protected IGameContextData _gameData = gameData;
        protected StateMachine _stateMachine = stateMachine;
        protected UI? _UI = (ConsoleUI?)gameData.Services.GetService<ConsoleUI>();

        public abstract void OnEnter();
        public abstract void DoStep();
    }
}