using System.Collections.Generic;
using StructureHelperCommon.Models.Forces;

namespace StructureHelperCommon.Infrastructures.Interfaces
{
    /// <summary>
    /// Интерфейс объектов, содержащих комбинации усилий (силовые воздействия).
    /// </summary>
    public interface IHasForceCombinations
    {
        /// <summary>
        /// Список силовых воздействий.
        /// </summary>
        List<IForceAction> ForceActions { get; }
    }
}