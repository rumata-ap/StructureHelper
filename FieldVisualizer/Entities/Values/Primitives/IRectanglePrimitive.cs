namespace FieldVisualizer.Entities.Values.Primitives
{
    /// <summary>
    /// Интерфейс прямоугольного примитива поля значений.
    /// </summary>
    internal interface IRectanglePrimitive : IValuePrimitive
    {
        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        double Height { get; set; }

        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        double Width { get; set; }
    }
}