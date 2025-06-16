using UnityEngine;
using UnityEngine.Events;

namespace AE
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable() => gameEvent.AddListener(this);

        private void OnDisable() => gameEvent.RemoveListener(this);

        public void OnEventTriggered() => response.Invoke();
    }
}
