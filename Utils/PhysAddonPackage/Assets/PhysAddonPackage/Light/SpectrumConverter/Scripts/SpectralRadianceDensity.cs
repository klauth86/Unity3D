using UnityEngine;

namespace PhysAddonPackage.Light.SpectrumConverter.Scripts {
    public delegate float SpectralRadianceDensity(float lambda);

    /// <summary>
    /// This class provides describtions
    /// for Light Spectral Radiance Density Functions
    /// and contains some examples.
    /// </summary>
    public static class Generator {
        /// <summary>
        /// Delta like Spectral Radiance Density around wavelength of lambda_0
        /// Demultiplier is used to sharpen the distribution
        /// </summary>
        /// <param name="lambda_0"></param>
        /// <returns></returns>
        public static SpectralRadianceDensity GenerateDeltaSpectralRadianceDensity(float lambda_0) {
            return new SpectralRadianceDensity(lambda => {
                return 4 * Mathf.Exp(-16 * Mathf.Pow(Constant.DemultiplierNano * (lambda - lambda_0), 2f)) / Mathf.Sqrt(Mathf.PI);
            });
        }

        /// <summary>
        /// Spectral Radiance Density of Black Body with temperature of T
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public static SpectralRadianceDensity GenerateBlackBodySpectralRadianceDensity(float T) {
            var k1 = 2 * Mathf.PI * Constant.Planck_H * Constant.SpeedOfLight_C * Constant.SpeedOfLight_C;
            var k2 = Constant.Planck_H * Constant.SpeedOfLight_C / Constant.Boltzmann_K;
            return new SpectralRadianceDensity(lambda => {
                return (k1 * Mathf.Pow(lambda, -5.0f)) /
                       (Mathf.Exp(k2 / (lambda * T)) - 1.0f);
            });
        }
    }
}
