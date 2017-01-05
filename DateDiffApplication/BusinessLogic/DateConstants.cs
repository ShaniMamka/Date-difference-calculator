using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateDiffApplication.BusinessLogic
{
    public class DateConstants
    {
        public const int NumOfDaysInMonth = 30;
        public const int NumOfDaysInLongMonth = 31;
        public const int NumOfDaysInFebruary = 28;
        public const int NumOfDaysInFebruaryLeapYear = 29;
        public const int NumOfDaysInYear = 365;
        public const int NumOfDaysInLeapYear = 366;

        public const int NewYearDay = 1;
        public const int NewYearMonth = 1;

        public const int EndYearDay = 31;
        public const int EndYearMonth = 12;

        public static readonly int[] LongMonthsArray = { 1, 3, 5, 7, 8, 10, 12 };
    }
}