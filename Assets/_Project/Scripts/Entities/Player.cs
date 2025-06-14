using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class Player : Entity<PlayerStateMachine>
    {
        public Vector2 MoveInput { get; private set; }

        private Transform _cameraTransform;

        protected override PlayerStateMachine CreateStateMachine() => new(this);

        protected override void Start()
        {
            base.Start();
            _cameraTransform = Camera.main.transform;

            StateMachine.SetIdleState();
        }

        public Vector3 GetMovementDirection(Vector2 input)
        {
            if (input == Vector2.zero || _cameraTransform == null) return Vector3.zero;

            Vector3 forward = _cameraTransform.forward;
            Vector3 right = _cameraTransform.right;

            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            return (forward * input.y + right * input.x).normalized;
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            MoveInput = ctx.ReadValue<Vector2>();
        }
    }
}
