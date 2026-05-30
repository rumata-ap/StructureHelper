namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс объектов, имеющих родительский (хозяющий) примитив.
    /// Используется для связи арматурного стержня с бетоном.
    /// </summary>
    public interface IHasHostPrimitive
    {
        /// <summary>
        /// Родительский примитив, в который вложен данный примитив.
        /// </summary>
        INdmPrimitive? HostPrimitive { get; set; }
    }
}