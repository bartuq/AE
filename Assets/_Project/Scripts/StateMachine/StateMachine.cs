namespace AE
{
    public abstract class StateMachine
    {
        private protected IState _currentState;

        public void ChangeState(IState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState?.Update();
    }
}
