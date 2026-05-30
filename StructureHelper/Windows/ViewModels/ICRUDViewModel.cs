using StructureHelper.Infrastructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StructureHelper.Windows.ViewModels
{
    /// <summary>
    /// Интерфейс ViewModel для операций CRUD (создание, чтение, обновление, удаление).
    /// </summary>
    /// <typeparam name="TItem">Тип элемента коллекции.</typeparam>
    public interface ICRUDViewModel<TItem>
    {
        /// <summary>
        /// Выбранный элемент коллекции.
        /// </summary>
        TItem SelectedItem { get; set; }

        /// <summary>
        /// Наблюдаемая коллекция элементов.
        /// </summary>
        ObservableCollection<TItem> Items { get; }

        /// <summary>
        /// Команда добавления нового элемента.
        /// </summary>
        ICommand Add { get; }

        /// <summary>
        /// Команда удаления выбранного элемента.
        /// </summary>
        ICommand Delete { get; }

        /// <summary>
        /// Команда редактирования выбранного элемента.
        /// </summary>
        ICommand Edit { get; }

        /// <summary>
        /// Команда копирования выбранного элемента.
        /// </summary>
        ICommand Copy { get; }

        /// <summary>
        /// Добавляет коллекцию элементов.
        /// </summary>
        /// <param name="items">Коллекция элементов для добавления.</param>
        void AddItems(IEnumerable<TItem> items);
    }
}