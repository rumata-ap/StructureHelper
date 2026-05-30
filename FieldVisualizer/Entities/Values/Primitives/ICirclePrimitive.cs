namespace FieldVisualizer.Entities.Values.Primitives
{
    /// <summary>
    /// Интерфейс круглого примитива поля значений.
    /// </summary>
    public interface ICirclePrimitive : IValuePrimitive
    {
        /// <summary>
        /// Диаметр круга.
        /// </summary>
        double Diameter { get; set; }
    }
}