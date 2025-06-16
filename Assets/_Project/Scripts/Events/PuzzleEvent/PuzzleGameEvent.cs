using System;
using System.Collections.Generic;
using UnityEngine;

namespace AE
{
    [CreateAssetMenu(fileName = "PuzzleEvent", menuName = "AE/Events/PuzzleEvent")]
    public class PuzzleGameEvent : ScriptableObject
    {
        private readonly List<PuzzleGameEventListener> listeners = new();

        public void TriggerEvent(int value, Player player, Action callback = null)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered(value, player, callback);
            }
        }

        public void AddListener(PuzzleGameEventListener listener)
        {
            if (listeners.Contains(listener)) return;
            listeners.Add(listener);
        }

        public void RemoveListener(PuzzleGameEventListener listener)
        {
            if (!listeners.Contains(listener)) return;
            listeners.Remove(listener);
        }
    }
}
