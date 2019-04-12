using UnityEngine;

public class PinSetter : MonoBehaviour {

    #region Cache
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _pinsPrefab;
    [SerializeField] private GameObject _pinsObject;
    #endregion

    public void Swipe() {
        _animator.SetTrigger("TidyTrigger");
    }

    public void Reset() {
        _animator.SetTrigger("ResetTrigger");
    }

    public void RaisePins() {
        foreach (var item in FindObjectsOfType<Pin>()) {
            if (item.IsStanding()) {
                item.Raise();
            }
        }
    }

    public void LowerPins() {
        foreach (var item in FindObjectsOfType<Pin>()) {
            if (item.IsStanding()) {
                item.Lower();
            }
        }
    }

    public void RenewPins() {
        if (_pinsObject) {
            Destroy(_pinsObject);
        }
        if (_pinsPrefab)
            _pinsObject = Instantiate(_pinsPrefab, new Vector3(0, 0, 18.55f), Quaternion.identity);
    }
}
