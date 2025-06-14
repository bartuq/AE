using UnityEngine;

namespace AE
{
    public abstract class Entity<T> : MonoBehaviour where T : StateMachine
    {
        protected T StateMachine { get; private set; }

        protected abstract T CreateStateMachine();

        protected virtual void Awake()
        {
            StateMachine = CreateStateMachine();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            StateMachine?.Update();
        }
    }
}
