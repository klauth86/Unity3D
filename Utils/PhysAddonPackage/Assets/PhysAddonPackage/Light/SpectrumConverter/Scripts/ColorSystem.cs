namespace PhysAddonPackage.Light.SpectrumConverter.Scripts {
    /// <summary>
    /// A colour system is defined by the CIE x and y coordinates of
    /// its three primary illuminants and the x and y coordinates of
    /// the white point.
    /// </summary>
    public class ColorSystem {
        public string name;                     /* Color system name */
        public float   xRed, yRed,              /* Red x, y */
                       xGreen, yGreen,          /* Green x, y */
                       xBlue, yBlue,            /* Blue x, y */
                       xWhite, yWhite,          /* White point x, y */
                       gamma;                   /* Gamma correction for system */

        public static ColorSystem NTSCsystem = new ColorSystem() { name = "NTSC", xRed = 0.67f, yRed = 0.33f, xGreen = 0.21f, yGreen = 0.71f, xBlue = 0.14f, yBlue = 0.08f, xWhite = 0.3101f, yWhite = 0.3162f, gamma = 0 };
        public static ColorSystem EBUsystem = new ColorSystem() { name = "EBU (PAL/SECAM)", xRed = 0.64f, yRed = 0.33f, xGreen = 0.29f, yGreen = 0.60f, xBlue = 0.15f, yBlue = 0.06f, xWhite = 0.3127f, yWhite = 0.3291f, gamma = 0 };
        public static ColorSystem SMPTEsystem = new ColorSystem() { name = "SMPTE", xRed = 0.630f, yRed = 0.340f, xGreen = 0.310f, yGreen = 0.595f, xBlue = 0.155f, yBlue = 0.070f, xWhite = 0.3127f, yWhite = 0.3291f, gamma = 0 };
        public static ColorSystem HDTVsystem = new ColorSystem() { name = "HDTV", xRed = 0.670f, yRed = 0.330f, xGreen = 0.210f, yGreen = 0.710f, xBlue = 0.150f, yBlue = 0.060f, xWhite = 0.3127f, yWhite = 0.3291f, gamma = 0 };
        public static ColorSystem CIEsystem = new ColorSystem() { name = "CIE", xRed = 0.7355f, yRed = 0.2645f, xGreen = 0.2658f, yGreen = 0.7243f, xBlue = 0.1669f, yBlue = 0.0085f, xWhite = 0.33333333f, yWhite = 0.33333333f, gamma = 0 };
        public static ColorSystem Rec709system = new ColorSystem() { name = "CIE REC 709", xRed = 0.64f, yRed = 0.33f, xGreen = 0.30f, yGreen = 0.60f, xBlue = 0.15f, yBlue = 0.06f, xWhite = 0.3127f, yWhite = 0.3291f, gamma = 0 };
    }
}