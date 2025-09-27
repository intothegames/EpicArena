using TimeToBeEpic.Game.Logic;
using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game
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
