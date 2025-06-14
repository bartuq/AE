using UnityEngine;

namespace AE
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            Debug.Log($"[{_stateMachine.Player.name}] Entering Move State");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log($"[{_stateMachine.Player.name}] Exiting Move State");
        }

        public override void Update()
        {
            base.Update();
            //Debug.Log($"[{_stateMachine.Player.name}] Move");
        }
        #endregion
    }
}
