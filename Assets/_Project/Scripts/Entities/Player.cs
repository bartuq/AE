using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class Player : Entity<PlayerStateMachine>
    {
        //[SerializeField] private StringGameEvent _labelEvent;
        //[SerializeField] private StringGameEvent _messageEvent;
        [Header("Interaction")]
        [field: SerializeField] public UsableItem Inventory { get; private set; }
        [SerializeField] private float _interactDistance = 3;
        [SerializeField] private LayerMask _interactLayerMask;

        public Vector2 MoveInput { get; private set; }

        private PlayerControls _inputActions;
        private Transform _cameraTransform;
        private IInteractable _currentInteractable;

        protected override PlayerStateMachine CreateStateMachine() => new(this);

        #region InputActions
        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Gameplay.Move.performed += OnMove;
            _inputActions.Gameplay.Move.canceled += OnMove;
            _inputActions.Gameplay.Interact.performed += OnInteract;
        }

        private void OnDisable()
        {
            _inputActions.Gameplay.Move.performed -= OnMove;
            _inputActions.Gameplay.Move.canceled -= OnMove;
            _inputActions.Gameplay.Interact.performed -= OnInteract;
            _inputActions.Disable();
        }
        #endregion

        protected override void Awake()
        {
            base.Awake();
            _inputActions = new PlayerControls();
        }

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

        public void DetectInteractable()
        {
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _interactDistance, _interactLayerMask))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    if (_currentInteractable == interactable) return;
                    Debug.Log("Interaction");
                    _currentInteractable = interactable;
                    _currentInteractable.ShowLabel();
                    return;
                }
            }

            if (_currentInteractable == null) return;
            _currentInteractable.HideLabel();
            _currentInteractable = null;
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            MoveInput = ctx.ReadValue<Vector2>();
        }

        public void OnInteract(InputAction.CallbackContext ctx)
        {
            if (_currentInteractable == null) return;
            _currentInteractable.Interact(this);
        }

        #region Inventory
        public bool HasRequiredItem(UsableItem item) => (Inventory & item) == item;

        public void AddItem(UsableItem item) => Inventory |= item;

        public void RemoveItem(UsableItem item) => Inventory &= ~item;
        #endregion

        /*
        public void ShowLabelEvent(string text, string message)
        {
            if (!_labelEvent || string.IsNullOrEmpty(text)) return;
            _labelEvent.TriggerEvent(text, () => MessageEvent(message));
        }

        public void HideLabelEvent(string message)
        {
            if (!_labelEvent) return;
            _labelEvent.TriggerEvent("", () => MessageEvent(message));
        }

        public void MessageEvent(string message)
        {
            if (!_messageEvent || string.IsNullOrEmpty(message)) return;
            _messageEvent.TriggerEvent(message);
        }
        */
    }
}
