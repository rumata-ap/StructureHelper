using System.Windows.Media;

namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс визуальных свойств примитива (отображение на экране).
    /// </summary>
    public interface IVisualProperty
    {
        /// <summary>
        /// Видимость примитива.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Цвет заливки примитива.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Использовать цвет материала вместо собственного цвета.
        /// </summary>
        bool SetMaterialColor { get; set; }

        /// <summary>
        /// Z-индекс (порядок наложения) примитива.
        /// </summary>
        int ZIndex { get; set; }

        /// <summary>
        /// Непрозрачность примитива (0.0 — полностью прозрачный, 1.0 — непрозрачный).
        /// </summary>
        double Opacity { get; set; }
    }
}