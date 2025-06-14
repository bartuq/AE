namespace AE
{
    public class Player : Entity<PlayerStateMachine>
    {
        protected override PlayerStateMachine CreateStateMachine() => new(this);

        protected override void Start()
        {
            base.Start();
            StateMachine.SetIdleState();
        }
    }
}
