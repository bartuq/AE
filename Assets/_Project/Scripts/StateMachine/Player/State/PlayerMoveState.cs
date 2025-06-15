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

            _stateMachine.Player.DetectInteractable();
            _stateMachine.Player.ApplyGravity();
            Move();
        }
        #endregion

        public void Move()
        {
            Vector2 input = _stateMachine.Player.MoveInput;
            if (input == Vector2.zero)
            {
                _stateMachine.SetIdleState();
                return;
            }

            Vector3 direction = _stateMachine.Player.GetMovementDirection(input);
            Vector3 move = _stateMachine.Player.Speed * Time.deltaTime * direction;

            //Vector3 move = _stateMachine.Player.Speed * Time.deltaTime * new Vector3(input.x, 0, input.y).normalized;
            _stateMachine.Player.Move(move);
        }
    }
}
