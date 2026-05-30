using StructureHelperLogics.Models.Materials;
using StructureHelperCommon.Models.Shapes;
using StructureHelper.Models.Materials;
using System.Collections;
using LoaderCalculator.Data.Ndms;
using LoaderCalculator.Data.Materials;
using System.Collections.Generic;
using StructureHelperCommon.Infrastructures.Interfaces;
using System;
using StructureHelperCommon.Models.Forces;
using StructureHelperLogics.Models.CrossSections;
using StructureHelperLogics.NdmCalculations.Triangulations;

namespace StructureHelperLogics.NdmCalculations.Primitives
{
    /// <summary>
    /// Интерфейс расчётного примитива поперечного сечения (НДМ-примитив).
    /// Представляет геометрическую фигуру с материалом, используемую для расчёта напряжённо-деформированного состояния.
    /// </summary>
    public interface INdmPrimitive : ISaveable, ICloneable
    {
        /// <summary>
        /// Наименование примитива.
        /// </summary>
        string? Name { get; set; }

        /// <summary>
        /// Центр тяжести примитива (точка в системе координат сечения).
        /// </summary>
        IPoint2D Center { get; }

        /// <summary>
        /// Поперечное сечение, которому принадлежит примитив.
        /// </summary>
        ICrossSection? CrossSection { get; set; }

        /// <summary>
        /// Материал примитива (бетон, арматура, упругий и т.д.).
        /// </summary>
        IHeadMaterial? HeadMaterial { get; set; }

        /// <summary>
        /// Признак триангуляции. Если true, примитив разбивается на элементарные НДМ-части.
        /// </summary>
        bool Triangulate { get; set; }

        /// <summary>
        /// Деформации предварительного напряжения, заданные пользователем.
        /// </summary>
        StrainTuple UsersPrestrain { get; }

        /// <summary>
        /// Автоматические деформации предварительного напряжения.
        /// </summary>
        StrainTuple AutoPrestrain { get; }

        /// <summary>
        /// Визуальные свойства примитива (цвет, прозрачность, Z-индекс).
        /// </summary>
        IVisualProperty VisualProperty {get; }

        /// <summary>
        /// Возвращает коллекцию НДМ-частей для расчёта на основе параметров триангуляции.
        /// </summary>
        /// <param name="triangulationOptions">Параметры триангуляции.</param>
        IEnumerable<INdm> GetNdms(ITriangulationOptions triangulationOptions);
    }
}