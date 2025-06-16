using UnityEngine;
using UnityEngine.UIElements;

namespace AE
{
    public class UIEndGame : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        private VisualElement _root, _background;
        private Button _quitButton;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            _background = _root.Q<VisualElement>("background");
            _background.AddToClassList("transition-background");

            _quitButton = _background.Q<Button>("quit-button");
            _quitButton.clicked += OnQuitClick;

            Hide();
        }

        public void Show()
        {
            _root.style.display = DisplayStyle.Flex;
            Pause();

            _background.schedule.Execute(() =>
            {
                _background.AddToClassList("visible");
            }).ExecuteLater(2000); // 2 seconds delay
        }

        public void Hide()
        {
            _background.RemoveFromClassList("visible");
            _root.style.display = DisplayStyle.None;
        }

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
            Time.timeScale = 0;
            _inputReader.DisableGameplayInput();
            _inputReader.PauseAction.Disable();
        }

        private void OnQuitClick() => Quit();
    }
}
