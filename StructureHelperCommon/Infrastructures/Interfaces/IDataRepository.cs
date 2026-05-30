using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureHelperCommon.Infrastructures.Interfaces
{
    /// <summary>
    /// Репозиторий данных для операций CRUD над сущностями типа <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public interface IDataRepository<T>
    {
        /// <summary>
        /// Создаёт новую сущность.
        /// </summary>
        /// <param name="entity">Сущность для создания.</param>
        void Create(T entity);

        /// <summary>
        /// Обновляет существующую сущность.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        void Update(T entity);

        /// <summary>
        /// Удаляет сущность по идентификатору.
        /// </summary>
        /// <param name="Id">Идентификатор сущности.</param>
        void Delete(Guid Id);

        /// <summary>
        /// Возвращает сущность по идентификатору.
        /// </summary>
        /// <param name="Id">Идентификатор сущности.</param>
        T GetById(Guid Id);

        /// <summary>
        /// Возвращает все сущности.
        /// </summary>
        List<T> GetAll();
    }
}