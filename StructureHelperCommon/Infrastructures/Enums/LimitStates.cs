namespace StructureHelperCommon.Infrastructures.Enums
{
    /// <summary>
    /// Предельные состояния сечения.
    /// </summary>
    public enum LimitStates
    {
        /// <summary>
        /// Предельное состояние по несущей способности (первая группа).
        /// </summary>
        ULS = 1,

        /// <summary>
        /// Предельное состояние по эксплуатационной пригодности (вторая группа).
        /// </summary>
        SLS = 2,

        /// <summary>
        /// Особое предельное состояние.
        /// </summary>
        Special = 3,
    }
}