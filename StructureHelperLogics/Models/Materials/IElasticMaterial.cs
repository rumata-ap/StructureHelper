using StructureHelperCommon.Models.Materials.Libraries;

namespace StructureHelperLogics.Models.Materials
{
    /// <summary>
    /// Упругий материал с постоянным модулем упругости.
    /// Используется для моделирования сталей, полимеров и других линейно-упругих материалов.
    /// </summary>
    public interface IElasticMaterial : IHelperMaterial
    {
        /// <summary>
        /// Модуль упругости (МПа).
        /// </summary>
        double Modulus { get; set; }

        /// <summary>
        /// Прочность на сжатие (МПа).
        /// </summary>
        double CompressiveStrength { get; set; }

        /// <summary>
        /// Прочность на растяжение (МПа).
        /// </summary>
        double TensileStrength { get; set; }

        /// <summary>
        /// Коэффициенты надёжности по материалу.
        /// </summary>
        List<IMaterialSafetyFactor> SafetyFactors { get; }
    }
}