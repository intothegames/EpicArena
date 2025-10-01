using EpicArena.Game.Constants;
using EpicArena.Game.Logic;
using EpicArena.Game.Services;

namespace EpicArena.Game.States
{
    class MainMenu(IGameContextData data, StateMachine stateMachine) : GameState(data, stateMachine)
    {
        private readonly Event _event = new();

        private ConsoleInput? _input;

        private Hero? _hero;
        private UnitStats? _stats;

        public override void OnEnter()
        {
            _input = (ConsoleInput?)_gameData.Services.GetService<ConsoleInput>();

            _hero = _gameData.Hero;
        }

        public override void DoStep()
        {
            _UI.Init();

            _gameData.ResetRounds();

            _stats = CreateRandomStats();

            _event.Call(DebugEvent.OnMainMenu, _stats);

            _UI?.ShowMainMenuScreen(_stats);

            HeroClassType Hero = _input.WaitForSelectHeroClass();
            ApplyNewHeroChoose(Hero);

            _stateMachine.SetStateRoundPreparing();

            _stateMachine.DoStep();
        }

        private void ApplyNewHeroChoose(HeroClassType heroCass)
        {
            switch (heroCass)
            {
                case HeroClassType.Rogue:
                    _hero.InitHero(new Rogue(), _stats);
                    break;

                case HeroClassType.Warrior:
                    _hero.InitHero(new Warrior(), _stats);
                    break;

                case HeroClassType.Barbarian:
                    _hero.InitHero(new Barbarian(), _stats);
                    break;
            }
        }

        public UnitStats CreateRandomStats()
        {
            return new UnitStats
            {
                [StatsType.Strength] = Random.Shared.Next(Values.MIN_RANDOM_STAT_VALUE, Values.MAX_RANDOM_STAT_VALUE + 1),
                [StatsType.Agility] = Random.Shared.Next(Values.MIN_RANDOM_STAT_VALUE, Values.MAX_RANDOM_STAT_VALUE + 1),
                [StatsType.Stamina] = Random.Shared.Next(Values.MIN_RANDOM_STAT_VALUE, Values.MAX_RANDOM_STAT_VALUE + 1)
            };
        }
    }
}