using StructureHelperCommon.Models.Shapes;

namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс круглого примитива поперечного сечения.
    /// </summary>
    public interface ICirclePrimitive : INdmPrimitive, IHasDivisionSize, ICircleShape
    {
    }
}