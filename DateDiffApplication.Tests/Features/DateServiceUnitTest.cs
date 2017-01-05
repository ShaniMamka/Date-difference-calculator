using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateDiffApplication.BusinessLogic;
using DateDiffApplication.Models;

namespace DateDiffApplication.Tests.Featers
{
    [TestClass]
    public class DateServiceUnitTest
    {
        [TestMethod]
        public void TestIsLeapYear()
        {
            // Known facts: 2020 is a leap year, and 2015 isn't.
            int leapYear = 2020;
            int nonLeapYear = 2015;

            Assert.AreEqual(true, DateService.IsLeapYear(leapYear));
            Assert.AreEqual(false, DateService.IsLeapYear(nonLeapYear));
        }

        [TestMethod]
        public void TestGetNumOfDaysInMonth()
        {
            Date februaryLeapYearDate = new Date(1, 2, 2020);
            Date februaryDate = new Date(1, 2, 2017);
            Date longMonthDate = new Date (1,3,2017);
            Date shortMonthDate = new Date (1,4,2017);

            Assert.AreEqual(DateConstants.NumOfDaysInFebruaryLeapYear, DateService.GetNumOfDaysInMonth(februaryLeapYearDate));
            Assert.AreEqual(DateConstants.NumOfDaysInFebruary, DateService.GetNumOfDaysInMonth(februaryDate));
            Assert.AreEqual(DateConstants.NumOfDaysInLongMonth, DateService.GetNumOfDaysInMonth(longMonthDate));
            Assert.AreEqual(DateConstants.NumOfDaysInMonth, DateService.GetNumOfDaysInMonth(shortMonthDate));

        }

        [TestMethod]
        public void TestGetMonthDiffInDays()
        {
            Date startDate1 = new Date(27, 2, 2015);
            Date endDate1 = new Date(7, 12, 2015);

            Date startDate2 = new Date(27, 3, 2015);
            Date endDate2 = new Date(30, 3, 2015);


            Assert.AreEqual(283,DateService.GetMonthDiffInDays(startDate1, endDate1));
            Assert.AreEqual(3, DateService.GetMonthDiffInDays(startDate2, endDate2));
        }

        [TestMethod]
        public void TestGetDateDiffInDays()
        {
            Date startDate1 = new Date(27, 12, 2015);
            Date endDate1 = new Date(27, 12, 2016);

            Date startDate2 = new Date(7, 3, 2015);
            Date endDate2 = new Date(27, 12, 2017);

            Date startDate3 = new Date(27, 2, 2015);
            Date endDate3 = new Date(27, 3, 2017);

            Date startDate4 = new Date(27, 3, 2015);
            Date endDate4 = new Date(7, 12, 2017);

            Date startDate5 = new Date(27, 3, 2015);
            Date endDate5 = new Date(7, 12, 2020);

            Date startDate6 = new Date(27, 3, 2015);
            Date endDate6 = new Date(11, 1, 2016);



            Assert.AreEqual(366, DateService.GetDateDiffInDays(startDate1, endDate1));
            Assert.AreEqual(1026, DateService.GetDateDiffInDays(startDate2, endDate2));
            Assert.AreEqual(759, DateService.GetDateDiffInDays(startDate3, endDate3));
            Assert.AreEqual(986, DateService.GetDateDiffInDays(startDate4, endDate4));
            Assert.AreEqual(2082, DateService.GetDateDiffInDays(startDate5, endDate5));
            Assert.AreEqual(290, DateService.GetDateDiffInDays(startDate6, endDate6));
        }
    }
}
