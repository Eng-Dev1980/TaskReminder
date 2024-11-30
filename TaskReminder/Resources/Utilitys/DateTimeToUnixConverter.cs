using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder.Resources.Utilitys
{
    class DateTimeToUnixConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            long? unix = value as long?;
            if (unix.HasValue)
            {
                return DateTimeOffset.FromUnixTimeSeconds(unix.Value);
            }
            return new DateTime();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            DateTimeOffset? dateTimeOffset = value as DateTime?;
            if (!dateTimeOffset.HasValue)
            {
                return new DateTimeOffset(DateTime.Today).ToUnixTimeSeconds();
            }
            return dateTimeOffset.Value.ToUnixTimeSeconds();
        }
    }
}
