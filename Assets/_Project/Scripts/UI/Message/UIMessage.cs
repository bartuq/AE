using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AE
{
    public class UIMessage : MonoBehaviour
    {
        private VisualElement _root;
        private Label _message;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _message = _root.Q<Label>("message-label");

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

            _message.text = text;
            _root.style.display = DisplayStyle.Flex;

            callback?.Invoke();
        }

        public void HideMessage()
        {
            _root.style.display = DisplayStyle.None;
        }
    }
}
