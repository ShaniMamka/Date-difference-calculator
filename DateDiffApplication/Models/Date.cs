using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateDiffApplication.Models
{
    public class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public Date()
        { }

        public Date(int day, int month, int year)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public Date(Date date)
        {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
        }
    }
}