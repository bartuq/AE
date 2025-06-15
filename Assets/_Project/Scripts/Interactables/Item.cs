using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private StringGameEvent _labelEvent;
        [SerializeField] private StringGameEvent _messageEvent;
        [SerializeField] private string _text;

        [Header("Events")]
        [SerializeField] private UnityEvent _onInteract;
        [SerializeField] private UnityEvent _onShowLabel;
        [SerializeField] private UnityEvent _onHideLabel;

        public string Label => _text;

        public void Interact()
        {
            Debug.Log("Item");
            _onInteract?.Invoke();
        }

        public void ShowLabel()
        {
            if ((!_labelEvent) || string.IsNullOrEmpty(_text)) return;
            _labelEvent.TriggerEvent(_text, _onShowLabel.Invoke);
        }

        public void HideLabel()
        {
            if (!_labelEvent) return;
            _labelEvent.TriggerEvent("", _onHideLabel.Invoke);
        }

        public void ShowMessage(string message)
        {
            if ((!_messageEvent) || string.IsNullOrEmpty(message)) return;
            _messageEvent.TriggerEvent(message);
        }

        public void DestroyItem() => Destroy(gameObject);
    }
}
