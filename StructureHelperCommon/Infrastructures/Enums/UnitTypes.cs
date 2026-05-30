namespace StructureHelperCommon.Infrastructures.Enums
{
    /// <summary>
    /// Типы единиц измерения, используемых в расчётах.
    /// </summary>
    public enum UnitTypes
    {
        /// <summary>
        /// Длина (мм, см, м).
        /// </summary>
        Length,

        /// <summary>
        /// Площадь (мм², см², м²).
        /// </summary>
        Area,

        /// <summary>
        /// Напряжение (МПа, кПа).
        /// </summary>
        Stress,

        /// <summary>
        /// Сила (кН, Н).
        /// </summary>
        Force,

        /// <summary>
        /// Момент (кН·м, Н·мм).
        /// </summary>
        Moment,

        /// <summary>
        /// Кривизна (1/м, 1/мм).
        /// </summary>
        Curvature
    }
}