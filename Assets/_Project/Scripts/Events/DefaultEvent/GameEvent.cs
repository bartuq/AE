using System.Collections.Generic;
using UnityEngine;

namespace AE
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "AE/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> listeners = new();

        public void TriggerEvent()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            if (listeners.Contains(listener)) return;
            listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener)) return;
            listeners.Remove(listener);
        }
    }
}
