using StructureHelper.Models.Materials;
using StructureHelperCommon.Models.Calculators;
using StructureHelperCommon.Models.Forces;
using StructureHelperLogics.Models.Materials;
using StructureHelperLogics.Models.Primitives;
using StructureHelperLogics.NdmCalculations.Analyses;
using StructureHelperLogics.NdmCalculations.Primitives;
using System.Collections.Generic;

namespace StructureHelperLogics.Models.CrossSections
{
    /// <summary>
    /// Репозиторий поперечного сечения: содержит примитивы, материалы, усилия и калькуляторы.
    /// </summary>
    public interface ICrossSectionRepository : IHasHeadMaterials, IHasPrimitives
    {
        /// <summary>
        /// Список силовых воздействий на сечение.
        /// </summary>
        List<IForceAction> ForceActions { get; }

        /// <summary>
        /// Список калькуляторов, привязанных к сечению.
        /// </summary>
        List<ICalculator> CalculatorsList { get; }
    }
}