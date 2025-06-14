namespace AE
{
    public class PlayerStateMachine : StateMachine
    {
        public Player Player { get; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }

        public PlayerStateMachine(Player player)
        {
            Player = player;
            IdleState = new PlayerIdleState(this);
            MoveState = new PlayerMoveState(this);
        }

        public void SetIdleState() => ChangeState(IdleState);

        public void SetMoveState() => ChangeState(MoveState);
    }
}
