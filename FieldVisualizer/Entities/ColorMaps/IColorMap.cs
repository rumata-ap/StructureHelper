using System.Collections.Generic;
using System.Windows.Media;

namespace FieldVisualizer.Entities.ColorMaps
{
    /// <summary>
    /// Интерфейс цветовой карты (палитры для визуализации поля).
    /// </summary>
    public interface IColorMap
    {
        /// <summary>
        /// Наименование цветовой карты.
        /// </summary>
        string Name { get;}

        /// <summary>
        /// Список цветов палитры.
        /// </summary>
        List<Color> Colors { get; }
    }
}