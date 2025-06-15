using UnityEngine;

namespace AE
{
    public class Item : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Item");
            Destroy(gameObject);
        }
    }
}
