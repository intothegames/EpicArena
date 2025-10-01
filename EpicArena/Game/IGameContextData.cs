using EpicArena.Game.Logic;
using EpicArena.Game.Services;

namespace EpicArena.Game
{
    public interface IGameContextData
    {
        public GameServices Services { get; }

        public Hero Hero { get; }
        public Enemy CurrentEnemy { get; }

        public int Round {  get; }

        public void NewRound();
        public void ResetRounds();
    }
}