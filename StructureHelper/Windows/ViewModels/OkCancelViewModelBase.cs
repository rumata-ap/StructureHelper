using StructureHelper.Infrastructure;
using System.Windows;
using System.Windows.Input;

namespace StructureHelper.Windows.ViewModels
{
    /// <summary>
    /// Базовый класс ViewModel для диалоговых окон с кнопками OK/Cancel.
    /// </summary>
    public abstract class OkCancelViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Родительское окно диалога.
        /// </summary>
        public Window ParentWindow { get; set; }

        /// <summary>
        /// Команда подтверждения (OK).
        /// </summary>
        public ICommand OkCommand => new RelayCommand(o => OkAction());

        /// <summary>
        /// Команда отмены (Cancel).
        /// </summary>
        public ICommand CancelCommand => new RelayCommand(o => CancelAction());

        /// <summary>
        /// Действие при отмене — закрывает окно с результатом false.
        /// </summary>
        public virtual void CancelAction()
        {
            ParentWindow.DialogResult = false;
            ParentWindow.Close();
        }

        /// <summary>
        /// Действие при подтверждении — закрывает окно с результатом true.
        /// </summary>
        public virtual void OkAction()
        {
            ParentWindow.DialogResult = true;
            ParentWindow.Close();
        }
    }
}