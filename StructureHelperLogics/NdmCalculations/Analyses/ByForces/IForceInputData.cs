using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Models.Forces;
using StructureHelperLogics.Models.Calculations.CalculationProperties;
using System.Collections.Generic;

namespace StructureHelperLogics.NdmCalculations.Analyses.ByForces
{
    /// <summary>
    /// Входные данные для калькулятора расчёта по усилиям.
    /// </summary>
    public interface IForceInputData
    {
        /// <summary>
        /// Длительности нагрузки для расчёта.
        /// </summary>
        IEnumerable<CalcTerms> CalcTerms { get; set; }

        /// <summary>
        /// Списки комбинаций усилий.
        /// </summary>
        IEnumerable<IForceCombinationList> ForceCombinationLists { get; set; }

        /// <summary>
        /// Параметры итерационного расчёта (точность, макс. число итераций).
        /// </summary>
        IIterationProperty IterationProperty { get; }

        /// <summary>
        /// Предельные состояния для расчёта.
        /// </summary>
        IEnumerable<LimitStates> LimitStates { get; set; }
    }
}