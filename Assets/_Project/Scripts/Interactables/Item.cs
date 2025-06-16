using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField, Min(-1)] private int _Id = -1;
        [SerializeField] private PuzzleGameEvent _puzzleEvent;

        [SerializeField] private UsableItem _requiredItem;
        [SerializeField] private StringGameEvent _labelEvent;
        [SerializeField] private StringGameEvent _messageEvent;
        [SerializeField] private string _text;

        [Header("Events")]
        [SerializeField] private UnityEvent _onInteract;
        [SerializeField] private UnityEvent _onShowLabel;
        [SerializeField] private UnityEvent _onHideLabel;

        public string Label => _text;

        /*
        private void Start()
        {
            // test
            transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
        }
        */

        public void Interact(Player player)
        {
            if (IsPuzzle(player)) return;
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

        public bool IsPuzzle(Player player)
        {
            if (!_puzzleEvent) return false;
            _puzzleEvent.TriggerEvent(_Id, player, _onInteract.Invoke);
            return true;
        }

        public void DestroyItem() => Destroy(gameObject);

        public void MoveVertical(int value) => transform.position += Vector3.up * value;
    }
}
