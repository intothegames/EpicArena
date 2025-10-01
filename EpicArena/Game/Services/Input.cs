using EpicArena.Game.Logic;

namespace EpicArena.Game.Services
{
    public abstract class Input : IGameService
    {
        public abstract HeroClassType WaitForSelectHeroClass();
        public abstract bool WaitForRestart();
        public abstract bool WaitForChooseNewWeapon();
    }
}