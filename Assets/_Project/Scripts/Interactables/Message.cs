using UnityEngine;

namespace AE
{
    public class Message : MonoBehaviour
    {
        [SerializeField] private StringGameEvent _messageEvent;
        [SerializeField, TextArea] private string _defaultMessage;
        [SerializeField, TextArea] private string _alternateMessage;

        public void ShowDefaultMessage()
        {
            if ((!_messageEvent) || string.IsNullOrEmpty(_defaultMessage)) return;
            _messageEvent.TriggerEvent(_defaultMessage);
        }

        public void ShowAlternateMessage()
        {
            if ((!_messageEvent) || string.IsNullOrEmpty(_alternateMessage)) return;
            _messageEvent.TriggerEvent(_alternateMessage);
        }
    }
}
