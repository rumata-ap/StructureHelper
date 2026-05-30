using StructureHelperCommon.Infrastructures.Exceptions;
using StructureHelperCommon.Services.Units;
using System;
using System.Globalization;
using System.Windows.Data;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Конвертер для отображения числовых значений типа double без преобразования единиц.
    /// Используется для безразмерных величин (коэффициенты, проценты).
    /// </summary>
    internal class PlainDouble : IValueConverter
    {
        /// <summary>
        /// Преобразует double в отображаемое значение.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (double)value;
            }
            catch(Exception)
            {
                return new StructureHelperException(ErrorStrings.DataIsInCorrect);
            }
        }

        /// <summary>
        /// Преобразует введённую строку в double, поддерживая запятую как разделитель.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return CommonOperation.ConvertToDoubleChangeComma((string)value);
            }
            catch (Exception)
            {
                return new StructureHelperException(ErrorStrings.DataIsInCorrect);
            }
        }
    }
}