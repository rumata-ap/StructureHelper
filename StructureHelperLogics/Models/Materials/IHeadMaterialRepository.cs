using StructureHelper.Models.Materials;
using System.Collections.Generic;

namespace StructureHelperLogics.Models.Materials
{
    /// <summary>
    /// Репозиторий головных материалов сечения.
    /// Управляет списком материалов (бетон, арматура и т.д.) и связью с родительским объектом.
    /// </summary>
    public interface IHeadMaterialRepository
    {
        /// <summary>
        /// Родительский объект (обычно поперечное сечение).
        /// </summary>
        object Parent { get; }

        /// <summary>
        /// Список головных материалов сечения.
        /// </summary>
        List<IHeadMaterial> HeadMaterials { get; set; }

        /// <summary>
        /// Регистрирует родительский объект для уведомлений об изменениях.
        /// </summary>
        /// <param name="obj">Родительский объект.</param>
        void RegisterParent(object obj);
    }
}