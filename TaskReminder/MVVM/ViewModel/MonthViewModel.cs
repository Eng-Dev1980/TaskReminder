using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;
using TaskReminder.MVVM.Model;

namespace TaskReminder.ViewModel
{
    public partial class MonthViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Days>? daysList = [];

        [ObservableProperty]
        DateTime selectedDateTime;

        public MonthViewModel()
        {
            selectedDateTime = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day);
            var dayCounts = DateTime.DaysInMonth(selectedDateTime.Year, selectedDateTime.Month);
            MonthDaysTableCreator(selectedDateTime.Year, selectedDateTime.Month, dayCounts);
        }

        public MonthViewModel(int year, int month, int day)
        {
            selectedDateTime = new DateTime(year: year, month: month, day);
            var dayCounts = DateTime.DaysInMonth(year, month);
            MonthDaysTableCreator(year, month, dayCounts);
        }


        private void MonthDaysTableCreator(int year, int month,int count)
        {
            daysList.Clear();
            for (int i = 1; i <= count; i++)
            {
                var today = new DateTime(year, month, i);
                daysList.Add(
                    new Days()
                    {
                        YearNumber = today.Year,
                        DayNumber = today.Day,
                        DayName = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(today.DayOfWeek),
                        DayNameAbbreviation = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(today.DayOfWeek),
                        MonthNumber = month,
                        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                        MonthNameAbbreviation = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month),
                        DateTimeOffset = today,
                    });
            }
        }

    }
}
