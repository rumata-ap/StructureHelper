using System;
using System.Windows.Input;

namespace StructureHelper.Infrastructure
{
    /// <summary>
    /// Реализация <see cref="ICommand"/> для делегирования выполнения команды.
    /// Используется в паттерне MVVM для привязки команд интерфейса к методам ViewModel.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        /// <summary>
        /// Событие изменения доступности команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Создаёт команду с действием выполнения и опциональным условием доступности.
        /// </summary>
        /// <param name="execute">Действие выполнения команды.</param>
        /// <param name="canExecute">Условие доступности команды (null — всегда доступна).</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Определяет, может ли команда быть выполнена.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public void Execute(object parameter) => execute(parameter);
    }
}