using System;
using UnityEngine;
using UnityEngine.Events;

namespace Util
{
    public abstract class State<T> : MonoBehaviour
    {
        public T next;
        public T previous;
        public UnityEvent onActiveEvent;
        public UnityEvent onInactiveEvent;

        public void Awake()
        {
            gameObject.SetActive(false);
        }
        public virtual void OnActive()
        {
            gameObject.SetActive(true);
            onActiveEvent.Invoke();
        }

        public virtual void OnInactive()
        {
            gameObject.SetActive(false);
            onInactiveEvent.Invoke();
        }
    }
}
