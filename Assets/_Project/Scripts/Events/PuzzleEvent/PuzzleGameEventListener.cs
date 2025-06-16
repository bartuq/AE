using System;
using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    [Serializable]
    public class PuzzleEvent : UnityEvent<int, Player, Action> { }

    public class PuzzleGameEventListener : MonoBehaviour
    {
        public PuzzleGameEvent gameEvent;
        public PuzzleEvent response;

        private void OnEnable() => gameEvent.AddListener(this);

        private void OnDisable() => gameEvent.RemoveListener(this);

        public void OnEventTriggered(int value, Player player, Action callback = null) => response.Invoke(value, player, callback);
    }
}
