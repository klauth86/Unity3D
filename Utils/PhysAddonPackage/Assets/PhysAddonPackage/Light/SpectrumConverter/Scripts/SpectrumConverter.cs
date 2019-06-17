﻿using UnityEngine;

namespace PhysAddonPackage.Light.SpectrumConverter.Scripts {
    public static class SpectrumConverter {
        public const float MinLambda = 380f;
        public const float MaxLambda = 780f;

        public static Color ConvertWavelengthToColor(SpectralRadianceDensity density) {
            float x = 0;
            float y = 0;
            float z = 0;
            float r = 0;
            float g = 0;
            float b = 0;

            spectrum_to_xyz(density, ref x, ref y, ref z);
            xyz_to_rgb(ColorSystem.SMPTEsystem, x, y, z, ref r, ref g, ref b);
            var isOutsider = constrain_rgb(ref r, ref g, ref b);
            norm_rgb(ref r, ref g, ref b);

            return new Color(r, g, b);
        }

        /// <summary>
        ///Calculate the CIE X, Y, and Z coordinates corresponding to
        ///a light source with spectral distribution given by  the
        ///function SPEC_INTENS, which is called with a series of
        ///wavelengths between 380 and 780 nm(the argument is
        ///expressed in meters), which returns emittance at  that
        ///wavelength in arbitrary units.The chromaticity
        ///coordinates of the spectrum are returned in the x, y, and z
        ///arguments which respect the identity:
        /// </summary>
        /// <param name="density"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void spectrum_to_xyz(SpectralRadianceDensity density, ref float x, ref float y, ref float z) {
            int i;
            float lambda, X = 0, Y = 0, Z = 0, XYZ;

            /* CIE colour matching functions xBar, yBar, and zBar for
               wavelengths from 380 through 780 nanometers, every 5
               nanometers.  For a wavelength lambda in this range:

                    cie_colour_match[(lambda - 380) / 5][0] = xBar
                    cie_colour_match[(lambda - 380) / 5][1] = yBar
                    cie_colour_match[(lambda - 380) / 5][2] = zBar

                To save memory, this table can be declared as floats
                rather than doubles; (IEEE) float has enough
                significant bits to represent the values. It's declared
                as a double here to avoid warnings about "conversion
                between floating-point types" from certain persnickety
                compilers. */

            float[,] cie_colour_match = new float[,] {
                {0.0014f,0.0000f,0.0065f}, {0.0022f,0.0001f,0.0105f}, {0.0042f,0.0001f,0.0201f},
                {0.0076f,0.0002f,0.0362f}, {0.0143f,0.0004f,0.0679f}, {0.0232f,0.0006f,0.1102f},
                {0.0435f,0.0012f,0.2074f}, {0.0776f,0.0022f,0.3713f}, {0.1344f,0.0040f,0.6456f},
                {0.2148f,0.0073f,1.0391f}, {0.2839f,0.0116f,1.3856f}, {0.3285f,0.0168f,1.6230f},
                {0.3483f,0.0230f,1.7471f}, {0.3481f,0.0298f,1.7826f}, {0.3362f,0.0380f,1.7721f},
                {0.3187f,0.0480f,1.7441f}, {0.2908f,0.0600f,1.6692f}, {0.2511f,0.0739f,1.5281f},
                {0.1954f,0.0910f,1.2876f}, {0.1421f,0.1126f,1.0419f}, {0.0956f,0.1390f,0.8130f},
                {0.0580f,0.1693f,0.6162f}, {0.0320f,0.2080f,0.4652f}, {0.0147f,0.2586f,0.3533f},
                {0.0049f,0.3230f,0.2720f}, {0.0024f,0.4073f,0.2123f}, {0.0093f,0.5030f,0.1582f},
                {0.0291f,0.6082f,0.1117f}, {0.0633f,0.7100f,0.0782f}, {0.1096f,0.7932f,0.0573f},
                {0.1655f,0.8620f,0.0422f}, {0.2257f,0.9149f,0.0298f}, {0.2904f,0.9540f,0.0203f},
                {0.3597f,0.9803f,0.0134f}, {0.4334f,0.9950f,0.0087f}, {0.5121f,1.0000f,0.0057f},
                {0.5945f,0.9950f,0.0039f}, {0.6784f,0.9786f,0.0027f}, {0.7621f,0.9520f,0.0021f},
                {0.8425f,0.9154f,0.0018f}, {0.9163f,0.8700f,0.0017f}, {0.9786f,0.8163f,0.0014f},
                {1.0263f,0.7570f,0.0011f}, {1.0567f,0.6949f,0.0010f}, {1.0622f,0.6310f,0.0008f},
                {1.0456f,0.5668f,0.0006f}, {1.0026f,0.5030f,0.0003f}, {0.9384f,0.4412f,0.0002f},
                {0.8544f,0.3810f,0.0002f}, {0.7514f,0.3210f,0.0001f}, {0.6424f,0.2650f,0.0000f},
                {0.5419f,0.2170f,0.0000f}, {0.4479f,0.1750f,0.0000f}, {0.3608f,0.1382f,0.0000f},
                {0.2835f,0.1070f,0.0000f}, {0.2187f,0.0816f,0.0000f}, {0.1649f,0.0610f,0.0000f},
                {0.1212f,0.0446f,0.0000f}, {0.0874f,0.0320f,0.0000f}, {0.0636f,0.0232f,0.0000f},
                {0.0468f,0.0170f,0.0000f}, {0.0329f,0.0119f,0.0000f}, {0.0227f,0.0082f,0.0000f},
                {0.0158f,0.0057f,0.0000f}, {0.0114f,0.0041f,0.0000f}, {0.0081f,0.0029f,0.0000f},
                {0.0058f,0.0021f,0.0000f}, {0.0041f,0.0015f,0.0000f}, {0.0029f,0.0010f,0.0000f},
                {0.0020f,0.0007f,0.0000f}, {0.0014f,0.0005f,0.0000f}, {0.0010f,0.0004f,0.0000f},
                {0.0007f,0.0002f,0.0000f}, {0.0005f,0.0002f,0.0000f}, {0.0003f,0.0001f,0.0000f},
                {0.0002f,0.0001f,0.0000f}, {0.0002f,0.0001f,0.0000f}, {0.0001f,0.0000f,0.0000f},
                {0.0001f,0.0000f,0.0000f}, {0.0001f,0.0000f,0.0000f}, {0.0000f,0.0000f,0.0000f}
            };

            for (i = 0, lambda = MinLambda; lambda <= MaxLambda; i++, lambda += 5) {
                float Me;
                Me = density(lambda * 1E-9f);
                X += Me * cie_colour_match[i, 0];
                Y += Me * cie_colour_match[i, 1];
                Z += Me * cie_colour_match[i, 2];
            }

            XYZ = (X + Y + Z);
            x = X / XYZ;
            y = Y / XYZ;
            z = Z / XYZ;
        }

        /// <summary>
        ///Given an additive tricolour system CS, defined by the CIE x
        ///and y chromaticities of its three primaries (z is derived
        ///trivially as 1-(x+y)), and a desired chromaticity (XC, YC,
        ///ZC) in CIE space, determine the contribution of each
        ///primary in a linear combination which sums to the desired
        ///chromaticity.  If the  requested chromaticity falls outside
        ///the Maxwell  triangle (colour gamut) formed by the three
        ///primaries, one of the r, g, or b weights will be negative.
        ///Caller can use constrain_rgb() to desaturate an
        ///outside-gamut colour to the closest representation within
        ///the available gamut and/or norm_rgb to normalise the RGB
        ///components so the largest nonzero component has value 1.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="xc"></param>
        /// <param name="yc"></param>
        /// <param name="zc"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public static void xyz_to_rgb(ColorSystem cs, float xc, float yc, float zc,
                ref float r, ref float g, ref float b) {
            float xr, yr, zr, xg, yg, zg, xb, yb, zb;
            float xw, yw, zw;
            float rx, ry, rz, gx, gy, gz, bx, by, bz;
            float rw, gw, bw;

            xr = cs.xRed; yr = cs.yRed; zr = 1 - (xr + yr);
            xg = cs.xGreen; yg = cs.yGreen; zg = 1 - (xg + yg);
            xb = cs.xBlue; yb = cs.yBlue; zb = 1 - (xb + yb);

            xw = cs.xWhite; yw = cs.yWhite; zw = 1 - (xw + yw);

            /* xyz . rgb matrix, before scaling to white. */
            rx = (yg * zb) - (yb * zg); ry = (xb * zg) - (xg * zb); rz = (xg * yb) - (xb * yg);
            gx = (yb * zr) - (yr * zb); gy = (xr * zb) - (xb * zr); gz = (xb * yr) - (xr * yb);
            bx = (yr * zg) - (yg * zr); by = (xg * zr) - (xr * zg); bz = (xr * yg) - (xg * yr);

            /* White scaling factors.
               Dividing by yw scales the white luminance to unity, as conventional. */
            rw = ((rx * xw) + (ry * yw) + (rz * zw)) / yw;
            gw = ((gx * xw) + (gy * yw) + (gz * zw)) / yw;
            bw = ((bx * xw) + (by * yw) + (bz * zw)) / yw;

            /* xyz . rgb matrix, correctly scaled to white. */
            rx = rx / rw; ry = ry / rw; rz = rz / rw;
            gx = gx / gw; gy = gy / gw; gz = gz / gw;
            bx = bx / bw; by = by / bw; bz = bz / bw;

            /* rgb of the desired point */
            r = (rx * xc) + (ry * yc) + (rz * zc);
            g = (gx * xc) + (gy * yc) + (gz * zc);
            b = (bx * xc) + (by * yc) + (bz * zc);
        }

        /// <summary>
        ///If the requested RGB shade contains a negative weight for
        ///one of the primaries, it lies outside the colour gamut
        ///accessible from the given triple of primaries.Desaturate
        ///it by adding white, equal quantities of R, G, and B, enough
        ///to make RGB all positive.  The function returns 1 if the
        ///components were modified, zero otherwise.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int constrain_rgb(ref float r, ref float g, ref float b) {
            float w;

            /* Amount of white needed is w = - min(0, *r, *g, *b) */
            w = (0 < r) ? 0 : r;
            w = (w < g) ? w : g;
            w = (w < b) ? w : b;
            w = -w;

            /* Add just enough white to make r, g, b all positive. */
            if (w > 0) {
                r += w; g += w; b += w;
                return 1;                     /* Colour modified to fit RGB gamut */
            }
            return 0;                         /* Colour within RGB gamut */
        }

        /// <summary>
        ///Normalise RGB components so the most intense(unless all    
        ///are zero) has a value of 1.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public static void norm_rgb(ref float r, ref float g, ref float b) {
            float greatest = Mathf.Max(r, Mathf.Max(g, b));
            if (greatest > 0) {
                r /= greatest;
                g /= greatest;
                b /= greatest;
            }
        }
    }
}
