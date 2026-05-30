using StructureHelperCommon.Models.Calculators;
using System.Collections.Generic;

namespace StructureHelperLogics.NdmCalculations.Analyses.ByForces
{
    /// <summary>
    /// Результаты расчёта по усилиям: список результатов для каждой комбинации.
    /// </summary>
    public interface IForcesResults : IResult
    {
        /// <summary>
        /// Описание результата расчёта.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Список результатов по каждой комбинации усилий.
        /// </summary>
        List<IForcesTupleResult> ForcesResultList { get; }

        /// <summary>
        /// Признак достоверности результатов расчёта.
        /// </summary>
        bool IsValid { get; set; }
    }
}