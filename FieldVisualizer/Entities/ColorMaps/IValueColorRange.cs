using System.Windows.Media;

namespace FieldVisualizer.Entities.ColorMaps
{
    /// <summary>
    /// Интерфейс цветового диапазона: связывает значение поля с цветом.
    /// </summary>
    public interface IValueColorRange
    {
        /// <summary>
        /// Признак активности диапазона.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Нижнее значение диапазона.
        /// </summary>
        double BottomValue { get; set; }

        /// <summary>
        /// Среднее значение диапазона.
        /// </summary>
        double AverageValue { get; set; }

        /// <summary>
        /// Верхнее значение диапазона.
        /// </summary>
        double TopValue {get;set;}

        /// <summary>
        /// Цвет нижней границы диапазона.
        /// </summary>
        Color BottomColor { get; set; }

        /// <summary>
        /// Цвет верхней границы диапазона.
        /// </summary>
        Color TopColor { get; set; }
    }
}