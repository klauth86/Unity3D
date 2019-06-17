using PhysAddonPackage;
using PhysAddonPackage.Light.SpectrumConverter.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour {
    [Header("UI Text element")]
    [SerializeField] private Text _text;

    [Header("Configuration")]
    [SerializeField] private float _lambdaRate;
    [SerializeField] private float _routineRate;

    private bool _isOn;
    private float _lambda;

    private void Awake() {
        _lambda = SpectrumConverter.MinLambda;
        UpdateUI();
    }

    private void OnEnable() {
        StartCoroutine(ColorSpectrumRoutine());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private IEnumerator ColorSpectrumRoutine() {
        while (true) {
            if (_isOn && SpectrumConverter.MaxLambda - _lambda >= _lambdaRate) {
                _lambda += _lambdaRate;
                UpdateUI();
            }
            else if (_lambda - SpectrumConverter.MinLambda >= _lambdaRate) {
                _lambda -= _lambdaRate;
                UpdateUI();
            }
            yield return new WaitForSeconds(_routineRate);
        }
    }

    private void UpdateUI() {
        var density = Generator.GenerateDeltaSpectralRadianceDensity(_lambda * Constant.MultiplierNano);
        var color = SpectrumConverter.ConvertWavelengthToColor(density);
        if (_text) {
            _text.color = color;
            _text.text = _lambda.ToString();
        }
        else {
            Debug.LogWarning("Text is not set on Inspector");
        }
    }

    public void Toggle() {
        _isOn = !_isOn;
    }
}