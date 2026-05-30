using StructureHelperCommon.Models.Shapes;

namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс прямоугольного примитива поперечного сечения.
    /// </summary>
    public interface IRectanglePrimitive : INdmPrimitive, IHasDivisionSize, IRectangleShape
    {
    }
}