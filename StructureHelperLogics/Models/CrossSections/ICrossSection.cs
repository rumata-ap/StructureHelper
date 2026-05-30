namespace StructureHelperLogics.Models.CrossSections
{
    /// <summary>
    /// Интерфейс поперечного сечения, содержащего ссылку на репозиторий сечения.
    /// </summary>
    public interface ICrossSection
    {
        /// <summary>
        /// Репозиторий поперечного сечения (примитивы, усилия, калькуляторы).
        /// </summary>
        ICrossSectionRepository SectionRepository { get; }
    }
}