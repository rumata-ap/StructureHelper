using LoaderCalculator.Data.Materials;
using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Infrastructures.Interfaces;
using StructureHelperLogics.Models.Materials;
using System.Windows.Media;

namespace StructureHelper.Models.Materials
{
    /// <summary>
    /// Интерфейс головного материала сечения (бетон, арматура, упругий и т.д.).
    /// Содержит диаграмму деформирования и коэффициенты надёжности.
    /// </summary>
    public interface IHeadMaterial : ISaveable, ICloneable
    {
        /// <summary>
        /// Наименование материала.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Цвет материала для визуализации.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Вспомогательный материал (коэффициенты, параметры диаграммы).
        /// </summary>
        IHelperMaterial HelperMaterial { get; set; }

        /// <summary>
        /// Возвращает материал для расчётной библиотеки LoaderCalculator.
        /// </summary>
        /// <param name="limitState">Предельное состояние (ULS/SLS).</param>
        /// <param name="calcTerm">Длительность нагрузки (кратковременная/длительная).</param>
        IMaterial GetLoaderMaterial(LimitStates limitState, CalcTerms calcTerm);

        /// <summary>
        /// Возвращает материал с учётом трещин для расчётной библиотеки.
        /// </summary>
        /// <param name="limitState">Предельное состояние (ULS/SLS).</param>
        /// <param name="calcTerm">Длительность нагрузки.</param>
        IMaterial GetCrackedLoaderMaterial(LimitStates limitState, CalcTerms calcTerm);
    }
}