using UnityEngine;

namespace AE
{
    public class Activator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _targets;

        public void Activate()
        {
            foreach (GameObject target in _targets)
            {
                if (target != null)
                {
                    target.SetActive(true);
                }
            }
        }

        public void Deactivate()
        {
            foreach (GameObject target in _targets)
            {
                if (target != null)
                {
                    target.SetActive(false);
                }
            }
        }
    }
}
