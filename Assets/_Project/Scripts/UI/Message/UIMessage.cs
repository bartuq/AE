using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AE
{
    public class UIMessage : MonoBehaviour
    {
        private VisualElement _root;
        private Label _messageLabel;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            _messageLabel = _root.Q<Label>("message-label");
            _messageLabel.AddToClassList("transition-message");

            HideMessage();
        }

        public void ShowMessage(string text, Action callback = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                HideMessage();
                callback?.Invoke();
                return;
            }

            if (_messageLabel.ClassListContains("fade-out"))
            {
                _messageLabel.RemoveFromClassList("fade-out");
            }

            _messageLabel.text = text;
            _root.style.display = DisplayStyle.Flex;

            _messageLabel.schedule.Execute(() =>
            {
                _messageLabel.AddToClassList("fade-out");
            }).ExecuteLater(4000); // 4 seconds delay

            callback?.Invoke();
        }

        public void HideMessage()
        {
            _root.style.display = DisplayStyle.None;
        }
    }
}
