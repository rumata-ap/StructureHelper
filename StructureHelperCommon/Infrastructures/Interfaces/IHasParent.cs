namespace StructureHelperCommon.Infrastructures.Interfaces
{
    /// <summary>
    /// Интерфейс объектов, имеющих родительский контейнер.
    /// </summary>
    public interface IHasParent
    {
        /// <summary>
        /// Родительский объект.
        /// </summary>
        object Parent { get; }

        /// <summary>
        /// Регистрирует текущий объект в родительском контейнере.
        /// </summary>
        void RegisterParent();
    }
}