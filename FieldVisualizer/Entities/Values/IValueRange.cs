namespace FieldVisualizer.Entities.Values
{
    /// <summary>
    /// Интерфейс диапазона значений поля.
    /// </summary>
    public interface IValueRange
    {
        /// <summary>
        /// Верхняя граница диапазона (максимальное значение).
        /// </summary>
        double TopValue { get; set; }

        /// <summary>
        /// Нижняя граница диапазона (минимальное значение).
        /// </summary>
        double BottomValue { get; set; }
    }
}