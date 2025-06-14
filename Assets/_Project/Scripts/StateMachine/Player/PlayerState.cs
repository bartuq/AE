namespace AE
{
    public class PlayerState : IState
    {
        private protected PlayerStateMachine _stateMachine;

        public PlayerState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}
