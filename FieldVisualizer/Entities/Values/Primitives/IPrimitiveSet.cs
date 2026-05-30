using System.Collections.Generic;

namespace FieldVisualizer.Entities.Values.Primitives
{
    /// <summary>
    /// Интерфейс набора примитивов поля значений (группа ячеек с одинаковым именем).
    /// </summary>
    public interface IPrimitiveSet
    {
        /// <summary>
        /// Наименование набора примитивов.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Коллекция примитивов поля значений.
        /// </summary>
        IEnumerable<IValuePrimitive> ValuePrimitives { get; }
    }
}