using System;
using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    [Serializable]
    public class StringEvent : UnityEvent<string, Action> { }

    public class StringGameEventListener : MonoBehaviour
    {
        public StringGameEvent gameEvent;
        public StringEvent response;

        private void OnEnable() => gameEvent.AddListener(this);

        private void OnDisable() => gameEvent.RemoveListener(this);

        public void OnEventTriggered(string text, Action callback = null) => response.Invoke(text, callback);
    }
}
