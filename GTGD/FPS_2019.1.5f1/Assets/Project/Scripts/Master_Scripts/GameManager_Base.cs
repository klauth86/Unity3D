using UnityEngine;

namespace FPS.Master {
    public abstract class GameManager_Base : MonoBehaviour {
        private GameManager_Master _master;
        public GameManager_Master Master {
            get { return _master ?? (_master = GetComponent<GameManager_Master>()); }
        }
    }
}
