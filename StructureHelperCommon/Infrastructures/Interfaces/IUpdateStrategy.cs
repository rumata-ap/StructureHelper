using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureHelperCommon.Infrastructures.Interfaces
{
    /// <summary>
    /// Стратегия обновления свойств объекта типа <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Тип обновляемого объекта.</typeparam>
    public interface IUpdateStrategy<T>
    {
        /// <summary>
        /// Обновляет свойства целевого объекта из исходного.
        /// </summary>
        /// <param name="targetObject">Целевой объект для обновления.</param>
        /// <param name="sourceObject">Исходный объект-источник данных.</param>
        void Update(T targetObject, T sourceObject);
    }
}