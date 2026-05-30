using StructureHelperCommon.Models.Calculators;
using StructureHelperCommon.Models.Parameters;
using System.Collections.Generic;

namespace StructureHelperLogics.NdmCalculations.Analyses.Geometry
{
    /// <summary>
    /// Результат расчёта геометрических характеристик сечения.
    /// </summary>
    public interface IGeometryResult : IResult
    {
        /// <summary>
        /// Текстовые параметры результата (наименования и значения геометрических характеристик).
        /// </summary>
        List<IValueParameter<string>> TextParameters { get; set; }
    }
}