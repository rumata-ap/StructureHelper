using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Models.Materials.Libraries;
using LCM = LoaderCalculator.Data.Materials;
using LCMB = LoaderCalculator.Data.Materials.MaterialBuilders;

namespace StructureHelperLogics.Models.Materials
{
    /// <summary>
    /// Логика параметров материала для расчётной библиотеки.
    /// Настраивает режимы расчёта (учёт растяжения, ползучести и т.д.).
    /// </summary>
    public interface IMaterialOptionLogic
    {
        /// <summary>
        /// Устанавливает параметры материала для расчётной библиотеки.
        /// </summary>
        /// <param name="materialOptions">Параметры материала LoaderCalculator.</param>
        void SetMaterialOptions(LCMB.IMaterialOptions materialOptions);
    }
}