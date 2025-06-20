using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class Player : Entity<PlayerStateMachine>
    {
        //[SerializeField] private StringGameEvent _labelEvent;
        //[SerializeField] private StringGameEvent _messageEvent;
        [field: SerializeField] public Item Inventory { get; private set; }
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private float _interactDistance = 3;
        [SerializeField] private LayerMask _interactLayerMask;
        [SerializeField] private AudioSource _audioSource;

        public Vector2 MoveInput { get; private set; }

        private Transform _cameraTransform;
        private IInteractable _currentInteractable;

        protected override PlayerStateMachine CreateStateMachine() => new(this);

        #region InputActions
        private void OnEnable()
        {
            _inputReader.MoveAction.performed += OnMove;
            _inputReader.MoveAction.canceled += OnMove;
            _inputReader.InteractAction.performed += OnInteract;
        }

        private void OnDisable()
        {
            _inputReader.MoveAction.performed -= OnMove;
            _inputReader.MoveAction.canceled -= OnMove;
            _inputReader.InteractAction.performed -= OnInteract;
        }
        #endregion

        /*
        protected override void Awake()
        {
            base.Awake();
        }
        */

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
                    //Debug.Log("Interaction");
                    _currentInteractable = interactable;
                    _currentInteractable.ShowLabel();
                    return;
                }
            }

            if (_currentInteractable == null) return;
            _currentInteractable.HideLabel();
            _currentInteractable = null;
        }

        #region Input
        public void OnMove(InputAction.CallbackContext ctx)
        {
            MoveInput = ctx.ReadValue<Vector2>();
        }

        public void OnInteract(InputAction.CallbackContext ctx)
        {
            if (_currentInteractable == null) return;
            _currentInteractable.Interact(this);
        }
        #endregion

        #region Inventory
        public bool HasRequiredItem(Item item) => (Inventory & item) == item;

        public void AddItem(Item item) => Inventory |= item;

        public void RemoveItem(Item item) => Inventory &= ~item;
        #endregion

        #region AudioSource
        public void PlayFootstepsSfx()
        {
            if (!_audioSource || !_audioSource.clip) return;
            _audioSource.Play();
        }

        public void StopFootstepsSfx()
        {
            if (!_audioSource) return;
            _audioSource.Stop();
        }
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
