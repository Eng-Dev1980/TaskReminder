using System.Globalization;
using TaskReminder.MVVM.Model;

namespace TaskReminder.Resources.Utilitys
{
    internal class DayTitleConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Days? day = value as Days;

            if (day != null)
            {
                return $"{day.MonthName} of {day.YearNumber}";
            }

            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
