using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace AE
{
    public class UIPause : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        private VisualElement _root;
        private Button _resumeButton, _quitButton;

        #region InputActions
        private void OnEnable()
        {
            _inputReader.PauseAction.performed += OnPause;
        }

        private void OnDisable()
        {
            _inputReader.PauseAction.performed -= OnPause;
        }
        #endregion

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            SetupButtons();
            Hide();
        }

        public void Show() => _root.style.display = DisplayStyle.Flex;
        public void Hide() => _root.style.display = DisplayStyle.None;

        private void Quit()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        private void Pause()
        {
            Show();
            Time.timeScale = 0;
            _inputReader.DisableGameplayInput();
        }

        private void Resume()
        {
            Hide();
            Time.timeScale = 1;
            _inputReader.EnableGameplayInput();
        }        

        #region Buttons
        private void SetupButtons()
        {
            _resumeButton = _root.Q<Button>("resume-button");
            _resumeButton.clicked += OnResumeClick;

            _quitButton = _root.Q<Button>("quit-button");
            _quitButton.clicked += OnQuitClick;
        }

        private void OnResumeClick() => Resume();
        private void OnQuitClick() => Quit();
        #endregion

        private void OnPause(InputAction.CallbackContext ctx)
        {
            if (_root.style.display == DisplayStyle.Flex)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
