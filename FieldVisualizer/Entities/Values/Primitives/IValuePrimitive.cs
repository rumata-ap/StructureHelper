using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldVisualizer.Entities.Values.Primitives
{
    /// <summary>
    /// Интерфейс примитива поля значений (элементарной ячейки визуализации).
    /// Содержит значение в центре и площадь для расчёта интегральных характеристик.
    /// </summary>
    public interface IValuePrimitive
    {
        /// <summary>
        /// Значение поля в центре примитива.
        /// </summary>
        double Value { get; }

        /// <summary>
        /// Координата X центра примитива.
        /// </summary>
        double CenterX { get; }

        /// <summary>
        /// Координата Y центра примитива.
        /// </summary>
        double CenterY { get; }

        /// <summary>
        /// Площадь примитива.
        /// </summary>
        double Area { get; }
    }
}