using UnityEngine;

public class Lane : MonoBehaviour {

    [SerializeField] private GameMaster _gameMaster;

    private void OnTriggerExit(Collider other) {
        var ball = other.gameObject.GetComponent<Ball>();
        if (ball && _gameMaster)
            _gameMaster.StartCountStanding();
    }
}
