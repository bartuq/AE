using UnityEngine;

namespace AE
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private StringGameEvent _audioEvent;
        [SerializeField] private string _audioName;

        public void Play()
        {
            if ((!_audioEvent) || string.IsNullOrEmpty(_audioName)) return;
            _audioEvent.TriggerEvent(_audioName);
        }
    }
}
