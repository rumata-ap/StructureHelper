using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Services.Units;
using System;
using System.Globalization;
using System.Windows.Data;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Базовый класс конвертера единиц измерения для привязки данных в WPF.
    /// Обеспечивает преобразование между внутренним представлением (мм, МПа, кН·м)
    /// и отображаемым в пользовательском интерфейсе.
    /// </summary>
    internal abstract class UnitBase : IValueConverter
    {
        /// <summary>
        /// Тип единицы измерения (длина, площадь, напряжение и т.д.).
        /// </summary>
        public abstract UnitTypes UnitType { get; }

        /// <summary>
        /// Текущая единица измерения (мм, МПа, кН·м и т.д.).
        /// </summary>
        public abstract IUnit CurrentUnit { get; }

        /// <summary>
        /// Наименование единицы измерения для отображения.
        /// </summary>
        public abstract string UnitName { get;}

        /// <summary>
        /// Преобразует значение из модели в отображаемое (ViewModel → View).
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CommonOperation.Convert(CurrentUnit, UnitName, value);
        }

        /// <summary>
        /// Преобразует введённое значение из отображаемого в модель (View → ViewModel).
        /// При ошибке преобразования показывает сообщение пользователю.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return CommonOperation.ConvertBack(UnitType, CurrentUnit, value);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show($"Value of {UnitName}={(string)value} is not correct", "Error of conversion", System.Windows.Forms.MessageBoxButtons.OK);
                return 0;
            }
        }
    }
}