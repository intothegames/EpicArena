namespace EpicArena.Game.States
{
    class StateMachine
    {
        private Dictionary<Type, GameState>? _gameStates;
        private GameState? _currentState;

        private IGameContextData _data;

        public StateMachine(IGameContextData data)
        {
            _data = data;
        }

        public void DoStep()
        {
            _currentState?.DoStep();
        }

        public void SetStateByDefault()
        {
            GameState state = GetState<MainMenu>();
            SetState(state);
        }

        public void SetStateMainMenu()
        {
            GameState state = GetState<MainMenu>();
            SetState(state);
        }

        public void SetStateRoundPreparing()
        {
            GameState state = GetState<RoundPreparing>();
            SetState(state);
        }

        public void SetStatePlayerTurn()
        {
            GameState state = GetState<PlayerTurn>();
            SetState(state);
        }

        public void SetStateEnemyTurn()
        {
            GameState state = GetState<EnemyTurn>();
            SetState(state);
        }

        public void SetStateRoundWin()
        {
            GameState state = GetState<RoundWin>();
            SetState(state);
        }
        public void SetStateRoundDefeat()
        {
            GameState state = GetState<RoundDefeat>();
            SetState(state);
        }

        public void InitStates()
        {
            _gameStates = new Dictionary<Type, GameState>
            {
                {typeof(MainMenu), new MainMenu(_data, this) },
                {typeof(RoundPreparing), new RoundPreparing(_data, this) },

                {typeof(PlayerTurn), new PlayerTurn(_data, this) },
                {typeof(EnemyTurn), new EnemyTurn(_data, this) },

                {typeof(RoundWin), new RoundWin(_data, this) },
                {typeof(RoundDefeat), new RoundDefeat(_data, this) }
            };
        }

        private void SetState(GameState newState)
        {
            _currentState = newState;
            _currentState.OnEnter();
        }

        private T GetState<T>() where T : GameState
        {
            var type = typeof(T);
            return (T)_gameStates[type];
        }
    }
}