using EpicArena.Game.Logic;

namespace EpicArena.Game.Services
{
    public abstract class UI : IGameService
    {
        public abstract void Init();
        public abstract void ShowMainMenuScreen(UnitStats unitStats);
        public abstract void ShowStartFightScreen(Hero hero, Enemy enemy, bool _isPlayerFirst, int round);

        public abstract void ShowHeroAttack(Hero hero, int damage, Enemy enemy);
        public abstract void ShowHeroMiss(Hero hero, Enemy enemy);
        public abstract void ShowEnemyAttack(Hero hero, int damage, Enemy enemy);
        public abstract void ShowEnemyMiss(Hero hero, Enemy enemy);

        public abstract void ShowRoundDefeatScreen();
        public abstract void ShowRoundWinScreen(Enemy enemy);
        public abstract void ShowGameWinScreen();
        public abstract void ShowGameOverScreen();
        public abstract void ShowLevelUp();
        public abstract void ShowWeaponChoose(Weapon weapon);
    }
}