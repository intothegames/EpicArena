using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game
{
    class BootStrap
    {
        private readonly GameContext Game = new GameContext();

        public void Init()
        {
            // HighPriority
            CreateGameContextService<DamageCalculator>();

            // WithoutDpendency
            CreateGameContextService<ConsoleUI>();
            CreateGameContextService<ConsoleInput>();

            CreateGameContextService<DebugLog>();
        }
        public void StartGame()
        {
            Game.StartGame();
        }

        private void CreateGameContextService<T>() where T : IGameService, new()
        {
            Game.Services.AddService<T> (new T());
        }
    }
}