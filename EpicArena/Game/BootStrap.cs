using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game
{
    class BootStrap
    {
        private readonly GameContext Game = new GameContext();

        public void Init()
        {
            HighPriority();
            WithoutDpendency();
        }
        public void StartGame()
        {
            Game.StartGame();
        }

        private void HighPriority()
        {
            CreateGameContextService<DamageCalculator>();
        }

        private void WithoutDpendency()
        {
            CreateGameContextService<ConsoleUI>();
            CreateGameContextService<ConsoleInput>();

            CreateGameContextService<DebugLog>();
        }

        private void CreateGameContextService<T>() where T : IGameService, new()
        {
            Game.Services.AddService<T> (new T());
        }
    }
}