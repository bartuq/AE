using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class Player : Entity<PlayerStateMachine>
    {
        public Vector2 MoveInput { get; private set; }

        protected override PlayerStateMachine CreateStateMachine() => new(this);

        protected override void Start()
        {
            base.Start();
            StateMachine.SetIdleState();
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            MoveInput = ctx.ReadValue<Vector2>();
        }
    }
}
