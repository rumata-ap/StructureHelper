using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Models.Materials;
using StructureHelperCommon.Models.Materials.Libraries;
using StructureHelperLogics.Models.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace StructureHelperLogics.Models.Materials
{
    /// <summary>
    /// Интерфейс библиотечного материала (из справочника).
    /// Расширяет <see cref="IHelperMaterial"/> нормативными характеристиками и коэффициентами.
    /// </summary>
    public interface ILibMaterial : IHelperMaterial
    {
        /// <summary>
        /// Сущность нормативных данных материала из библиотеки.
        /// </summary>
        ILibMaterialEntity MaterialEntity { get; set; }

        /// <summary>
        /// Список коэффициентов надёжности по материалу.
        /// </summary>
        List<IMaterialSafetyFactor> SafetyFactors { get; }

        /// <summary>
        /// Логика расчёта диаграммы деформирования материала.
        /// </summary>
        IMaterialLogic MaterialLogic { get; set; }

        /// <summary>
        /// Доступные логики расчёта диаграмм.
        /// </summary>
        List<IMaterialLogic> MaterialLogics { get; }

        /// <summary>
        /// Возвращает прочностные характеристики материала (сжатие, растяжение) для заданных предельных состояний.
        /// </summary>
        /// <param name="limitState">Предельное состояние.</param>
        /// <param name="calcTerm">Длительность нагрузки.</param>
        (double Compressive, double Tensile) GetStrength(LimitStates limitState, CalcTerms calcTerm);
    }
}