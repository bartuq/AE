using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    [Flags]
    public enum Item
    {
        None = 0,
        Sword = 1 << 0,
        Skulls = 1 << 1
    }

    [Serializable]
    public class PuzzleStage
    {
        public Item requiredItem = Item.None;
        public bool removeItem = false;
        [TextArea] public string successMessage;
        [TextArea] public string failedMessage;
        public UnityEvent onComplete;
        public UnityEvent onFailed;
    }

    public class Puzzle : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _Id;
        [SerializeField] private StringGameEvent _messageEvent;
        [SerializeField] private List<PuzzleStage> _stages = new();
        private int _currentStage;

        public void ProgressPuzzle(int id, Player player, Action callback = null)
        {
            if ((id != _Id) || IsComplete) return;

            PuzzleStage stage = _stages[_currentStage];
            if (!HasItemRequired(stage, player.Inventory))
            {
                ShowMessage(stage.failedMessage);
                stage.onFailed?.Invoke();
                return;
            }
            if (HasItemToRemove(stage))
            {
                player.RemoveItem(stage.requiredItem);
            }
            ExecuteStage(stage, callback);
        }

        public bool IsComplete => _currentStage >= _stages.Count;

        private bool HasItemRequired(PuzzleStage stage, Item item)
        {
            return stage.requiredItem == Item.None || item.HasFlag(stage.requiredItem);
        }

        private bool HasItemToRemove(PuzzleStage stage)
        {
            return stage.removeItem && stage.requiredItem != Item.None;
        }

        private void ExecuteStage(PuzzleStage stage, Action callback)
        {
            ShowMessage(stage.successMessage);
            stage.onComplete?.Invoke();
            callback?.Invoke();
            _currentStage++;

            Debug.Log($"Puzzle Id: {_Id}, stage: {_currentStage}");
        }

        private void ShowMessage(string message)
        {
            if ((!_messageEvent) || string.IsNullOrEmpty(message)) return;
            _messageEvent.TriggerEvent(message);
        }
    }
}
