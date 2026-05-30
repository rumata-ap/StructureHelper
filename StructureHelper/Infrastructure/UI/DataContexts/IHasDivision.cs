using StructureHelper.Windows.ViewModels.NdmCrossSections;

namespace StructureHelper.Infrastructure.UI.DataContexts
{
    /// <summary>
    /// Интерфейс объектов, содержащих ViewModel параметров деления (разбиения на НДМ-части).
    /// </summary>
    internal interface IHasDivision
    {
        /// <summary>
        /// ViewModel параметров деления (минимальный размер элемента, число делений).
        /// </summary>
        HasDivisionViewModel HasDivisionViewModel { get; }
    }
}