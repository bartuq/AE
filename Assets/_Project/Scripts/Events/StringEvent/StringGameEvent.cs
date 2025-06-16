using System;
using System.Collections.Generic;
using UnityEngine;

namespace AE
{
    [CreateAssetMenu(fileName = "Event", menuName = "AE/Events/StringEvent")]
    public class StringGameEvent : ScriptableObject
    {
        private readonly List<StringGameEventListener> listeners = new();

        public void TriggerEvent(string text, Action callback = null)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered(text, callback);
            }
        }

        public void AddListener(StringGameEventListener listener)
        {
            if (listeners.Contains(listener)) return;
            listeners.Add(listener);
        }

        public void RemoveListener(StringGameEventListener listener)
        {
            if (!listeners.Contains(listener)) return;
            listeners.Remove(listener);
        }
    }
}
