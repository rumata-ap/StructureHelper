using StructureHelperCommon.Models.Shapes;

namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс точечного примитива (сосредоточенная арматура).
    /// </summary>
    public interface IPointPrimitive : INdmPrimitive, IPointShape
    {
    }
}