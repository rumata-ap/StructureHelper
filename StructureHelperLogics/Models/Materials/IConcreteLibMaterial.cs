using StructureHelperCommon.Models.Materials.Libraries;

namespace StructureHelperLogics.Models.Materials
{
    /// <summary>
    /// Бетонный библиотечный материал. Расширяет <see cref="ILibMaterial"/> параметрами,
    /// специфичными для бетона (учёт растяжения, влажность).
    /// </summary>
    public interface IConcreteLibMaterial : ILibMaterial
    {
        /// <summary>
        /// Учитывать работу бетона на растяжение при расчёте по предельным состояниям первой группы (ULS).
        /// </summary>
        bool TensionForULS { get; set; }

        /// <summary>
        /// Учитывать работу бетона на растяжение при расчёте по предельным состояниям второй группы (SLS).
        /// </summary>
        bool TensionForSLS { get; set; }

        /// <summary>
        /// Относительная влажность окружающей среды (влияет на ползучесть и усадку).
        /// </summary>
        double RelativeHumidity { get; set; }
    }
}