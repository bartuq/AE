using UnityEngine;

namespace AE
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class Entity<T> : MonoBehaviour where T : StateMachine
    {
        [field: SerializeField] public float Speed { get; private set; } = 5;

        protected CharacterController _controller;
        protected T StateMachine { get; private set; }

        private Vector3 _velocity;
        private readonly float _gravity = -9.81f;

        protected virtual void Awake()
        {
            StateMachine = CreateStateMachine();
            _controller = GetComponent<CharacterController>();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            StateMachine?.Update();
        }

        protected abstract T CreateStateMachine();

        public virtual void Move(Vector3 motion)
        {
            _controller.Move(motion);
        }

        public void Rotate(Vector3 target)
        {
            transform.LookAt(transform.position + target);
        }

        public void ApplyGravity()
        {
            bool isGrounded = _controller.isGrounded;

            if (isGrounded && (_velocity.y < 0))
            {
                _velocity.y = 0f;
            }

            _velocity.y += _gravity * Time.deltaTime;

            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}
