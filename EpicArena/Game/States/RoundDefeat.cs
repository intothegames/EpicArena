using TimeToBeEpic.Game.Services;

namespace TimeToBeEpic.Game.States
{
    class RoundDefeat(IGameContextData data, StateMachine stateMachine) : GameState(data, stateMachine)
    {
        private readonly Event _event = new();

        private ConsoleInput? _input;

        public override void OnEnter()
        {
            _input = (ConsoleInput?)_gameData.Services.GetService<ConsoleInput>();
        }

        public override void DoStep()
        {
            _event.Call(DebugEvent.OnRoundDefeat);

            _UI?.ShowRoundDefeatScreen();

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

            Console.Clear();
        }
    }
}