using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder.MVVM.Model
{
    //Not Include in DB
    public class Days
    {
        private DateTimeOffset _dateTimeOffset;
        public DateTimeOffset DateTimeOffset
        {
            get { return _dateTimeOffset; }
            set { _dateTimeOffset = value; }
        }


        private int _yearNumber;
        public int YearNumber
        {
            get { return _yearNumber; }
            set { _yearNumber = value; }
        }



        private int _monthNumber;
        public int MonthNumber
        {
            get { return _monthNumber; }
            set { _monthNumber = value; }
        }



        private string? _monthName;
        public string? MonthName
        {
            get { return _monthName; }
            set { _monthName = value; }
        }



        private string? _monthNameAbbreviation;
        public string? MonthNameAbbreviation
        {
            get { return _monthNameAbbreviation; }
            set { _monthNameAbbreviation = value; }
        }



        private int _dayNumber;
        public int DayNumber
        {
            get { return _dayNumber; }
            set { _dayNumber = value; }
        }



        private string? _dayName;
        public string? DayName
        {
            get { return _dayName; }
            set { _dayName = value; }
        }



        private string? _dayNameAbbreviation;
        public string? DayNameAbbreviation
        {
            get { return _dayNameAbbreviation; }
            set { _dayNameAbbreviation = value; }
        }

    }
}
