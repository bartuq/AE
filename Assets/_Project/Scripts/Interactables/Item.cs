using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public class Item : BaseItem
    {
        [SerializeField] private UnityEvent _onFailedInteract;
        [SerializeField] private UsableItem _requiredItem = UsableItem.None;
        [SerializeField] private UsableItem _addItem = UsableItem.None;

        /*
        private void Start()
        {
            // test
            transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
        }
        */

        public override void Interact(Player player)
        {
            if (!player.HasRequiredItem(_requiredItem))
            {
                _onFailedInteract?.Invoke();
                return;
            }

            if (IsPickable())
            {
                if (player.HasRequiredItem(_addItem))
                {
                    _onFailedInteract?.Invoke();
                    return;
                }
                player.AddItem(_addItem);
            }

            base.Interact(player);
        }

        public bool IsPickable() => _addItem != UsableItem.None;
    }
}
