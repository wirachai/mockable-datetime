using System;
using NUnit.Framework;

namespace MockableDateTime.Test
{
    [TestFixture]
    class SystemTimeTest
    {
        [TearDown]
        public void TearDown()
        {
            SystemTime.ResetDateTime();
        }

        [Test]
        public void Today_ShouldReturnSameValueAsMockDateTime()
        {
            var mockDate = new DateTime(2017, 04, 15);
            SystemTime.SetDateTime(mockDate);

            AssertTimeDiffInMillisecond(mockDate, SystemTime.Today);
        }

        [Test]
        public void Now_ShouldBeSameAsDateTimeNow()
        {
            AssertTimeDiffInMillisecond(DateTime.Now, SystemTime.Now);
        }

        [Test]
        public void Now_ShouldReturnSmallDifferInMilliSecondFromMockDateTime()
        {
            var mockDate = new DateTime(2017, 04, 15, 9, 20, 30);
            SystemTime.SetDateTime(mockDate);

            AssertTimeDiffInMillisecond(mockDate, SystemTime.Now);
        }

        [Test]
        public void UtcNow_ShouldBeSameAsDateTimeUtcNow()
        {
            AssertTimeDiffInMillisecond(DateTime.UtcNow, SystemTime.UtcNow);
        }

        private void AssertTimeDiffInMillisecond(DateTime t1, DateTime t2)
        {
            var diff = t1 - t2;
            Assert.IsTrue(Math.Abs(diff.TotalSeconds) < 0.01);
        }
    }
}
