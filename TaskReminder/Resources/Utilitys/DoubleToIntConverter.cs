using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder.Resources.Utilitys
{
    class DoubleToIntConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var vl = value as double?;
            if (vl != null)
                return (int)vl.Value;

            return 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var vl = value as int?;
            if (vl != null)
                return (double)vl.Value;

            return 0;
        }
    }
}
