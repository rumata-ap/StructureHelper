using System;
using System.Collections.Generic;
using System.Text;

namespace FieldVisualizer.InfraStructures.Enums
{
    /// <summary>
    /// Типы цветовых карт для визуализации поля напряжений.
    /// </summary>
    public enum ColorMapsTypes
    {
        /// <summary>
        /// Полный спектр (радуга).
        /// </summary>
        FullSpectrum = 0,

        /// <summary>
        /// От красного к белому.
        /// </summary>
        RedToWhite = 1,

        /// <summary>
        /// От красного к синему.
        /// </summary>
        RedToBlue = 2,

        /// <summary>
        /// От синего к белому.
        /// </summary>
        BlueToWhite = 3
    }
}