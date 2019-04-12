using UnityEngine;
using TMPro;

public class CanvasProxy : MonoBehaviour {
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private SpaceShip _ship;

    private void Update()
    {
        if (_scoreText)
        _scoreText.text = "Your Score is " + GameInstance.Instance.GetScore().ToString();
        if (_healthText)
        {
            if (_ship)
                _healthText.text = _ship.GetHealth().ToString();
            else
                _healthText.text = "0";
        }
    }
}
