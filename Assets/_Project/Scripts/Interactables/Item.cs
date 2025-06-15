using UnityEngine;

namespace AE
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private StringGameEvent _stringEvent;
        [SerializeField] private string _text;

        public void Interact()
        {
            Debug.Log("Item");
            Destroy(gameObject);
        }

        public void Show()
        {
            if (!_stringEvent || string.IsNullOrEmpty(_text)) return;
            _stringEvent.TriggerEvent(_text);
        }

        public void Hide()
        {
            if (!_stringEvent) return;
            _stringEvent.TriggerEvent("");
        }
    }
}
