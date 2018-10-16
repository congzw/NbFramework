using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.Common.Data
{
    [TestClass]
    public class NbValueSpecs
    {
        [TestMethod]
        public void TellState_UnStarted_should_ok()
        {
            DateTime start = new DateTime(2000, 1, 1, 1, 0, 0);
            var range = DateTimeRange.CreateHourRange(start, 1); //1:00~2:00
            DateTime now = new DateTime(2000, 1, 1, 0, 59, 0); //0:59

            range.TellState(now).ShouldEqual(DateRangeState.Unstart);
        }

        [TestMethod]
        public void TellState_Processing_should_ok()
        {
            DateTime start = new DateTime(2000, 1, 1, 1, 0, 0);
            var range = DateTimeRange.CreateHourRange(start, 1); //1:00~2:00
            DateTime now = new DateTime(2000, 1, 1, 1, 30, 0); //1:00
            DateTime now2 = new DateTime(2000, 1, 1, 1, 30, 0); //1:30
            DateTime now3 = new DateTime(2000, 1, 1, 2, 0, 0); //2:00

            range.TellState(now).ShouldEqual(DateRangeState.Processing);
            range.TellState(now2).ShouldEqual(DateRangeState.Processing);
            range.TellState(now3).ShouldEqual(DateRangeState.Processing);
        }

        [TestMethod]
        public void TellState_End_should_ok()
        {
            DateTime start = new DateTime(2000, 1, 1, 1, 0, 0);
            var range = DateTimeRange.CreateHourRange(start, 1); //1:00~2:00
            DateTime now = new DateTime(2000, 1, 1, 2, 1, 0); //2:01

            range.TellState(now).ShouldEqual(DateRangeState.End);
        }


        [TestMethod]
        public void CreateThisDayRange_should_ok()
        {
            var now = new DateTime(2000, 1, 4, 6, 6, 6); //2000-01-03 ~ 2000-01-09 59:59:59
            DateTimeRange.CreateThisDayRange(now).ShouldOK(new DateTime(2000, 1, 4), new DateTime(2000, 1, 4).AddDays(1).AddMilliseconds(-1));
        }

        [TestMethod]
        public void CreateThisWeekRange_should_ok()
        {
            var now = new DateTime(2000, 1, 4, 6, 6, 6); //2000-01-03 ~ 2000-01-09 59:59:59
            DateTimeRange.CreateThisWeekRange(now, DayOfWeek.Monday, 0).ShouldOK(new DateTime(2000, 1, 3), new DateTime(2000, 1, 3).AddDays(7).AddMilliseconds(-1));
            DateTimeRange.CreateThisWeekRange(now, DayOfWeek.Monday, 1).ShouldOK(new DateTime(2000, 1, 10), new DateTime(2000, 1, 10).AddDays(7).AddMilliseconds(-1));
        }

        [TestMethod]
        public void CreateThisMonthRange_should_ok()
        {
            var now = new DateTime(2000, 1, 4, 6, 6, 6); //2000-01-03
            DateTimeRange.CreateThisMonthRange(now, 0).ShouldOK(new DateTime(2000, 1, 1), new DateTime(2000, 1, 1).AddMonths(1).AddMilliseconds(-1));
            DateTimeRange.CreateThisMonthRange(now, 1).ShouldOK(new DateTime(2000, 2, 1), new DateTime(2000, 2, 1).AddMonths(1).AddMilliseconds(-1));
        }
    }

    public static class DateTimeRangeExts
    {
        public static void ShouldOK(this DateTimeRange expectRange, DateTime start, DateTime end)
        {
            expectRange.Start.ToString("yyyy-MM-dd HH:mm:ss").ShouldEqual(start.ToString("yyyy-MM-dd HH:mm:ss"));
            expectRange.End.ToString("yyyy-MM-dd HH:mm:ss").ShouldEqual(end.ToString("yyyy-MM-dd HH:mm:ss"));
            AssertHelper.WriteLine("---------");
        }
    }
}
