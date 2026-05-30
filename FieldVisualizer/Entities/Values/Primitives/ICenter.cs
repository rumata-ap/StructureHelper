namespace FieldVisualizer.Entities.Values.Primitives
{
    /// <summary>
    /// Интерфейс объекта с координатами центра.
    /// </summary>
    public interface ICenter
    {
        /// <summary>
        /// Координата X центра.
        /// </summary>
        double CenterX { get;}

        /// <summary>
        /// Координата Y центра.
        /// </summary>
        double CenterY { get;}
    }
}