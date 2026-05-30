namespace StructureHelper.Infrastructure.UI.DataContexts
{
    /// <summary>
    /// Интерфейс объектов, имеющих координаты левого верхнего угла.
    /// </summary>
    internal interface IHasCenter
    {
        /// <summary>
        /// Левая координата примитива.
        /// </summary>
        double PrimitiveLeft { get; }

        /// <summary>
        /// Верхняя координата примитива.
        /// </summary>
        double PrimitiveTop { get; }
    }
}