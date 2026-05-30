namespace StructureHelperCommon.Infrastructures.Enums
{
    /// <summary>
    /// Напряжённые состояния поперечного сечения.
    /// </summary>
    public enum SectionStressStates
    {
        /// <summary>
        /// Сечение растянуто.
        /// </summary>
        Tension,

        /// <summary>
        /// Сечение сжато.
        /// </summary>
        Compressed,

        /// <summary>
        /// Сечение испытывает изгиб (комбинированное напряжённое состояние).
        /// </summary>
        Combined
    }
}