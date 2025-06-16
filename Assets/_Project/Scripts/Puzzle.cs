using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    [Flags]
    public enum UsableItem
    {
        None = 0,
        Sword = 1 << 0,
        Skulls = 1 << 1
    }

    [Serializable]
    public class PuzzleStage
    {
        public UsableItem requiredItem = UsableItem.None;
        public bool removeItem = false;
        [TextArea] public string message;
        public UnityEvent onComplete;
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
            if (!HasItemRequired(stage, player.Inventory)) return;
            if (HasItemToRemove(stage))
            {
                player.RemoveItem(stage.requiredItem);
            }
            ExecuteStage(stage, callback);
        }

        public bool IsComplete => _currentStage >= _stages.Count;

        private bool HasItemRequired(PuzzleStage stage, UsableItem item)
        {
            return stage.requiredItem == UsableItem.None || item.HasFlag(stage.requiredItem);
        }

        private bool HasItemToRemove(PuzzleStage stage)
        {
            return stage.removeItem && stage.requiredItem != UsableItem.None;
        }

        private void ExecuteStage(PuzzleStage stage, Action callback)
        {
            ShowMessage(stage.message);
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
