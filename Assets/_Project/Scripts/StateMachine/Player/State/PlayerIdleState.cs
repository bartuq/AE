using UnityEngine;

namespace AE
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            Debug.Log($"[{_stateMachine.Player.name}] Entering Idle State");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log($"[{_stateMachine.Player.name}] Exiting Idle State");
        }

        public override void Update()
        {
            base.Update();
            //Debug.Log($"[{_stateMachine.Player.name}] Idle");

            _stateMachine.Player.ApplyGravity();

            Vector2 input = _stateMachine.Player.MoveInput;
            if (input != Vector2.zero)
            {
                _stateMachine.SetMoveState();
                return;
            }
        }
        #endregion
    }
}
