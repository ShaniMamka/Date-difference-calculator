using DateDiffApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateDiffApplication.BusinessLogic
{
    public static class DateService
    {
        /*
         Input: start date and end date
         OutPut: the number of days in between the 2 dates.
         */
        public static int GetDateDiffInDays(Date startDate, Date endDate)
        {
            int dateDiffInDays = 0;
            Date currentDate = new Date(startDate);

            while (endDate.Year > currentDate.Year)
            {
                dateDiffInDays += addYearInDays(currentDate.Year);
                currentDate.Year++;
            }
            dateDiffInDays += GetMonthDiffInDays(currentDate, endDate);
            return dateDiffInDays;
        }

        /*
         Input: start date and end date
         OutPut: the number of days in between the 2 dates based on the month.
         */
        public static int GetMonthDiffInDays(Date startDate, Date endDate)
        {
            int monthsDiffInDays = 0;
            Date currentDate = new Date(startDate);
 
            while (currentDate.Month != endDate.Month)
            {
                if (currentDate.Month > endDate.Month)
                {
                    monthsDiffInDays -= GetNumOfDaysInMonth(currentDate);
                    currentDate.Month--;

                    //Check month range 1-12
                    if(currentDate.Month == 0)
                    {
                        currentDate.Month = 12;
                    }
                }
                else
                {
                    monthsDiffInDays += GetNumOfDaysInMonth(currentDate);
                    currentDate.Month++;

                    //Check month range 1-12
                    if (currentDate.Month == 13)
                    {
                        currentDate.Month = 1;
                    }
                }
                              
            }
            //check if current year is a leap year                       
            if (IsLeapYear(currentDate.Year))
            {
                monthsDiffInDays++;
            }
            monthsDiffInDays += (endDate.Day - currentDate.Day);
            return monthsDiffInDays;
        }

        /*
         Input: year
         Output: True if it's a leap year, else False.
         1. The year can be evenly divided by 4;
         2. If the year can be evenly divided by 100, it is NOT a leap year, unless;
         3. The year is also evenly divisible by 400. Then it is a leap year.
         */
        public static bool IsLeapYear(int year)
        {

            if ((year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0)))
            {
                return true;
            }

            return false;
        }

        /*
         Input: month number , is a leap year flag.
         Output: The number of days that month.
         */
        public static int GetNumOfDaysInMonth(Date date)
        {
            bool isLeapYear = IsLeapYear(date.Year);
            //Check number of days in February (can be a leap year).
            if (date.Month == 2)
            {
                if (isLeapYear)
                {
                    return DateConstants.NumOfDaysInFebruaryLeapYear;
                }
                return DateConstants.NumOfDaysInFebruary;
            }
            else if (DateConstants.LongMonthsArray.Contains(date.Month))
            {
                return DateConstants.NumOfDaysInLongMonth;
            }
            else
            {
                return DateConstants.NumOfDaysInMonth;
            }
        }

        /*
         Input: year
         OutPut: the number of days in a specific year.
         */
        public static int addYearInDays(int year)
        {
                if (IsLeapYear(year))
                {
                    return DateConstants.NumOfDaysInLeapYear;
                }
                else
                {
                    return DateConstants.NumOfDaysInYear;
                }
        }
    }
}