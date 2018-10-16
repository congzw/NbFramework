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

            range.TellState(now).ShouldEqual(DateRangeState.UnStarted);
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

    }
}
