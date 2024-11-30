using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder.Resources.Utilitys
{
    internal class UnixToDateTimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            long? unix = value as long?;
            if (unix.HasValue)
            {
                var dt = DateTimeOffset.FromUnixTimeSeconds(unix.Value);
                return dt.ToString().Split('+')[0];
            }

            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? timeString = value as string;
            int month, day, year, hour, minute, second;



            if (timeString is not null)

            {
                string[] splited = timeString.Split('/');
                if (splited.Length > 0)
                {
                    month = int.Parse(splited[0]);
                    day = int.Parse(splited[1]);
                    year = int.Parse(splited[2][..4]);

                    splited = splited[3][5..].Split(':');

                    hour = int.Parse(splited[1]);
                    minute = int.Parse(splited[2]);
                    second = int.Parse(splited[3][..2]);

                    return new DateTimeOffset(year, month, day, hour, minute
                        , second, TimeSpan.Zero).ToUnixTimeSeconds();

                }
            }

            return 0;
        }
    }
}
