using UnityEngine;

namespace FPS {
    public abstract class Subscriber_Base<T> : MonoBehaviour where T : MonoBehaviour {
        private T _master;
        public T Master {
            get { return _master ?? (_master = GetComponent<T>()); }
        }
    }
}