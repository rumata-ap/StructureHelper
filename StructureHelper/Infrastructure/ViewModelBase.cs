using System.ComponentModel;
using System.Runtime.CompilerServices;
using StructureHelper.Properties;

namespace StructureHelper.Infrastructure
{
    /// <summary>
    /// Базовый класс ViewModel с реализацией <see cref="INotifyPropertyChanged"/>.
    /// Предоставляет методы для уведомления об изменении свойств.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Уведомляет об изменении свойства.
        /// </summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="value">Новое значение.</param>
        /// <param name="prop">Ссылка на поле свойства.</param>
        /// <param name="propertyName">Имя свойства (определяется автоматически).</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged<T>(T value, T prop, [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Устанавливает новое значение свойства и уведомляет об изменении.
        /// </summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="value">Новое значение.</param>
        /// <param name="prop">Ссылка на поле свойства (ref).</param>
        /// <param name="propertyName">Имя свойства (определяется автоматически).</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged<T>(T value, ref T prop, [CallerMemberName] string propertyName = null)
        {
            prop = value;
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Уведомляет об изменении свойства по имени.
        /// </summary>
        /// <param name="propertyName">Имя свойства (определяется автоматически).</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}