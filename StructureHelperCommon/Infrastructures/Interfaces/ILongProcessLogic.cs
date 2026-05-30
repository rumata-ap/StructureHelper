using StructureHelperCommon.Models.Calculators;
using StructureHelperCommon.Models.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StructureHelperCommon.Infrastructures.Interfaces
{
    /// <summary>
    /// Интерфейс логики длительного процесса с поддержкой прогресса и трассировки.
    /// </summary>
    public interface ILongProcessLogic
    {
        /// <summary>
        /// Количество шагов процесса.
        /// </summary>
        int StepCount { get; }

        /// <summary>
        /// Действие для обновления прогресса. Принимает значение процента завершения.
        /// </summary>
        Action<int> SetProgress { get; set; }

        /// <summary>
        /// Результат выполнения процесса.
        /// </summary>
        bool Result { get; set; }

        /// <summary>
        /// Логгер трассировки процесса.
        /// </summary>
        IShiftTraceLogger? TraceLogger { get; set; }

        /// <summary>
        /// Основная рабочая метод фонового потока.
        /// </summary>
        void WorkerDoWork(object sender, DoWorkEventArgs e);

        /// <summary>
        /// Обработчик изменения прогресса.
        /// </summary>
        void WorkerProgressChanged(object sender, ProgressChangedEventArgs e);

        /// <summary>
        /// Обработчик завершения фоновой работы.
        /// </summary>
        void WorkerRunWorkCompleted(object sender, RunWorkerCompletedEventArgs e);
    }
}