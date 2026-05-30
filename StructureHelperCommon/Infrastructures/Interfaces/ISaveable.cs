using System;

namespace StructureHelperCommon.Infrastructures.Interfaces
{
    /// <summary>
    /// Интерфейс объектов, поддерживающих сохранение с уникальным идентификатором.
    /// </summary>
    public interface ISaveable
    {
        /// <summary>
        /// Уникальный идентификатор объекта.
        /// </summary>
        Guid Id { get;}
    }
}