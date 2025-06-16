using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public abstract class BaseItem : MonoBehaviour , IInteractable
    {
        [SerializeField] private StringGameEvent _labelEvent;
        [SerializeField] private string _label;

        [Header("Events")]
        [SerializeField] protected UnityEvent _onInteract;
        [SerializeField] protected UnityEvent _onShowLabel;
        [SerializeField] protected UnityEvent _onHideLabel;

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

        public void DestroyItem() => Destroy(gameObject);

        public void MoveVertical(int value) => transform.position += Vector3.up * value;
    }
}
