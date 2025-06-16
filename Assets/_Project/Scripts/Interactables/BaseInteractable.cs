using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public abstract class BaseInteractable : MonoBehaviour , IInteractable
    {
        [SerializeField] protected UnityEvent _onInteract;
        [SerializeField] protected UnityEvent _onShowLabel;
        [SerializeField] protected UnityEvent _onHideLabel;

        [SerializeField] private StringGameEvent _labelEvent;
        [SerializeField] private string _label;

        public string Label => _label;

        public virtual void Interact(Player player)
        {
            _onInteract?.Invoke();
        }

        public void ShowLabel()
        {
            if (!_labelEvent || string.IsNullOrEmpty(_label)) return;
            _labelEvent.TriggerEvent(_label, _onShowLabel.Invoke);
        }

        public void HideLabel()
        {
            if (!_labelEvent) return;
            _labelEvent.TriggerEvent("", _onHideLabel.Invoke);
        }

        public void DestroyObject() => Destroy(gameObject);

        public void MoveVertical(float value) => transform.position += Vector3.up * value;
    }
}
