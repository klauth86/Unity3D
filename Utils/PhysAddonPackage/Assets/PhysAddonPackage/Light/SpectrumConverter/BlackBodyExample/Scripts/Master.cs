using PhysAddonPackage.Light.SpectrumConverter.Scripts;
using UnityEngine;


namespace PhysAddonPackage.Light.SpectrumConverter.BlackBodyExample.Scripts {
    public class Master : MonoBehaviour {
        [Header("The temperature of candle's light")]
        [SerializeField] private float T1;
        [SerializeField] private UnityEngine.Light L1;

        [Header("The temperature of North sky light")]
        [SerializeField] private float T2;
        [SerializeField] private UnityEngine.Light L2;

        [Header("The temperature of Bellatrix in Orion constellation")]
        [SerializeField] private float T3;
        [SerializeField] private UnityEngine.Light L3;

        private void OnEnable() {
            var density1 = Generator.GenerateBlackBodySpectralRadianceDensity(T1);
            var color1 = Converter.ConvertDensityToVisibleSpectralColor(density1);
            if (L1) {
                L1.color = color1;
            }
            else {
                Debug.LogWarning("L1 is not set in Inspector!");
            }

            var density2 = Generator.GenerateBlackBodySpectralRadianceDensity(T2);
            var color2 = Converter.ConvertDensityToVisibleSpectralColor(density2);
            if (L2) {
                L2.color = color2;
            }
            else {
                Debug.LogWarning("L2 is not set in Inspector!");
            }

            var density3 = Generator.GenerateBlackBodySpectralRadianceDensity(T3);
            var color3 = Converter.ConvertDensityToVisibleSpectralColor(density3);
            if (L3) {
                L3.color = color3;
            }
            else {
                Debug.LogWarning("L3 is not set in Inspector!");
            }
        }
    }
}