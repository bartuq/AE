using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AE
{
    public class UIInteraction : MonoBehaviour
    {
        private VisualElement _root, _container;
        private Label _label;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _container = _root.Q<VisualElement>("text-container");
            _label = _container.Q<Label>("text-label");

            HideInteraction();
        }

        public void ShowInteraction(string text, Action callback = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                HideInteraction();
                callback?.Invoke();
                return;
            }

            _label.text = text;
            _container.style.display = DisplayStyle.Flex;

            callback?.Invoke();
        }

        public void HideInteraction()
        {
            _container.style.display = DisplayStyle.None;
        }
    }
}
