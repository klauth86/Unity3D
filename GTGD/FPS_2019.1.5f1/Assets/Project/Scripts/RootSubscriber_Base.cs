using UnityEngine;

namespace FPS {
    public abstract class RootSubscriber_Base<T> : MonoBehaviour where T : MonoBehaviour {
        private T _master;
        public T Master {
            get { return _master ?? (_master = transform.root.GetComponent<T>()); }
        }
    }
}