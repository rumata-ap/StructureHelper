using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Infrastructures.Interfaces;
using StructureHelperCommon.Models.Calculators;
using StructureHelperCommon.Models.Forces;
using StructureHelperCommon.Models.Sections;
using StructureHelperLogics.NdmCalculations.Primitives;
using System.Collections.Generic;

namespace StructureHelperLogics.NdmCalculations.Analyses.ByForces
{
    /// <summary>
    /// Калькулятор расчёта сечения по усилиям.
    /// Выполняет проверку прочности и трещиностойкости по заданным комбинациям нагрузок.
    /// </summary>
    public interface IForceCalculator : ICalculator, IHasPrimitives, IHasForceCombinations
    {
        /// <summary>
        /// Список длительностей нагрузки для расчёта.
        /// </summary>
        List<CalcTerms> CalcTermsList { get; }

        /// <summary>
        /// Список предельных состояний для расчёта.
        /// </summary>
        List<LimitStates> LimitStatesList { get; }

        /// <summary>
        /// Параметры сжатого элемента (для учёта эффектов второго порядка).
        /// </summary>
        ICompressedMember CompressedMember { get; }

        /// <summary>
        /// Точность итерационного расчёта.
        /// </summary>
        IAccuracy Accuracy { get; set; }

        /// <summary>
        /// Списки комбинаций усилий.
        /// </summary>
        List<IForceCombinationList> ForceCombinationLists { get;}
    }
}