using UnityEngine;

namespace AE
{
    public class PuzzleItem : BaseItem
    {
        [SerializeField, Min(-1)] private int _Id = -1;
        [SerializeField] private PuzzleGameEvent _puzzleEvent;

        public override void Interact(Player player)
        {
            TriggerPuzzle(player);
        }

        private void TriggerPuzzle(Player player)
        {
            if (!_puzzleEvent) return;
            _puzzleEvent.TriggerEvent(_Id, player, _onInteract.Invoke);
        }
    }
}
