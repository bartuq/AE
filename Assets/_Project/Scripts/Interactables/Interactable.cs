using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public class Interactable : BaseInteractable
    {
        [SerializeField] private UnityEvent _onFailedInteract;
        [SerializeField] private Item _requiredItem = Item.None;
        [SerializeField] private Item _addItem = Item.None;

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

        public bool IsPickable() => _addItem != Item.None;
    }
}
