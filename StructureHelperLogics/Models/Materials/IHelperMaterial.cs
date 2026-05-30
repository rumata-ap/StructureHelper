using LoaderCalculator.Data.Materials;
using StructureHelperCommon.Infrastructures.Enums;

namespace StructureHelperLogics.Models.Materials
{
    /// <summary>
    /// Вспомогательный интерфейс материала, предоставляющий диаграмму деформирования
    /// для расчётной библиотеки LoaderCalculator.
    /// </summary>
    public interface IHelperMaterial : ICloneable
    {
        /// <summary>
        /// Возвращает материал для расчёта.
        /// </summary>
        /// <param name="limitState">Предельное состояние (ULS/SLS).</param>
        /// <param name="calcTerm">Длительность нагрузки.</param>
        IMaterial GetLoaderMaterial(LimitStates limitState, CalcTerms calcTerm);

        /// <summary>
        /// Возвращает материал с учётом трещин для расчёта ширины раскрытия трещин.
        /// </summary>
        /// <param name="limitState">Предельное состояние (ULS/SLS).</param>
        /// <param name="calcTerm">Длительность нагрузки.</param>
        IMaterial GetCrackedLoaderMaterial(LimitStates limitState, CalcTerms calcTerm);
    }
}