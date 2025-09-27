using TimeToBeEpic.Game.Logic;

namespace TimeToBeEpic.Game.Services
{
    public abstract class Input : IGameService
    {
        public abstract HeroClassType WaitForSelectHeroClass();
        public abstract bool WaitForRestart();
        public abstract bool WaitForChooseNewWeapon();
    }
}
