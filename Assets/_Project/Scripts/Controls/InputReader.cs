using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "AE/InputReader")]
    public class InputReader : ScriptableObject
    {
        private PlayerControls _inputActions;

        public void OnEnable()
        {
            _inputActions ??= new();
            _inputActions.Enable();
        }

        public void OnDisable()
        {
            _inputActions.Disable();
        }

        #region Gameplay Action
        public InputAction MoveAction => _inputActions.Gameplay.Move;
        public InputAction LookAction => _inputActions.Gameplay.Look;
        public InputAction InteractAction => _inputActions.Gameplay.Interact;
        #endregion

        #region UI Action
        public InputAction NavigateAction => _inputActions.UI.Navigate;
        public InputAction SubmitAction => _inputActions.UI.Submit;
        public InputAction CancelAction => _inputActions.UI.Cancel;
        public InputAction PointAction => _inputActions.UI.Point;
        public InputAction ClickAction => _inputActions.UI.Click;
        public InputAction RightClickAction => _inputActions.UI.RightClick;
        public InputAction MiddleClickAction => _inputActions.UI.MiddleClick;
        public InputAction ScrollWheelAction => _inputActions.UI.ScrollWheel;
        public InputAction TrackedDevicePositionAction => _inputActions.UI.TrackedDevicePosition;
        public InputAction TrackedDeviceOrientationAction => _inputActions.UI.TrackedDeviceOrientation;
        public InputAction PauseAction => _inputActions.UI.Pause;
        #endregion

        public void EnableGameplayInput() => _inputActions.Gameplay.Enable();
        public void DisableGameplayInput() => _inputActions.Gameplay.Disable();
    }
}
