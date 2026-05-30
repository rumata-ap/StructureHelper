using System.Collections.Generic;

namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс объектов, содержащих коллекцию расчётных примитивов.
    /// </summary>
    public interface IHasPrimitives
    {
        /// <summary>
        /// Список расчётных примитивов поперечного сечения.
        /// </summary>
        List<INdmPrimitive> Primitives { get; }
    }
}