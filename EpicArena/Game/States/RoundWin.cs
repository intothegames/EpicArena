using TimeToBeEpic.Game.Constants;
using TimeToBeEpic.Game.Logic;
using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game.States
{
    class RoundWin(IGameContextData data, StateMachine stateMachine) : GameState(data, stateMachine)
    {
        private readonly Event _event = new();

        private ConsoleInput? _input;

        private Hero _hero;
        private Enemy _enemy;

        private int _rounds;

        public override void OnEnter()
        {
            _input = (ConsoleInput?)_gameData.Services.GetService<ConsoleInput>();

            _hero = _gameData.Hero;
            _enemy = _gameData.CurrentEnemy;

            _rounds = _gameData.Round;
        }

        public override void DoStep()
        {
            _event.Call(DebugEvent.OnRoundWin, _rounds);

            _UI.ShowRoundWinScreen(_enemy);

            if (_rounds >= Values.ROUNDS_TO_WIN)
            {
                _UI.ShowGameWinScreen();

                if (_input.WaitForRestart())
                {
                    _stateMachine.SetStateMainMenu();
                    _stateMachine.DoStep();
                }
                else
                {
                    _UI.ShowGameOverScreen();
                    Environment.Exit(0);
                }
            }

            if (_hero.Level < Values.MAX_HERO_LEVEL)
            {
                _UI.ShowLevelUp();

                HeroClassType newHeroClass = _input.WaitForSelectHeroClass();
                ApplyNewClassChoose(newHeroClass);
            }

            _UI.ShowWeaponChoose((Weapon)_enemy.Loot);

            if (_input.WaitForChooseNewWeapon())
            {
                _hero.SetWeapon((Weapon)_enemy.Loot);
            }

            _stateMachine.SetStateRoundPreparing();
            _stateMachine.DoStep();
        }

        private void ApplyNewClassChoose(HeroClassType heroCass)
        {
            switch (heroCass)
            {
                case HeroClassType.Rogue:
                    _hero.LevelUp(new Rogue());
                    break;

                case HeroClassType.Warrior:
                    _hero.LevelUp(new Warrior());
                    break;

                case HeroClassType.Barbarian:
                    _hero.LevelUp(new Barbarian());
                    break;
            }
        }
    }
}