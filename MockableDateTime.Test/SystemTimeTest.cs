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

            Assert.AreEqual(mockDate, SystemTime.Today);
        }

        [Test]
        public void Now_ShouldBeSameAsDateTimeNow()
        {
            var result = DateTime.Compare(DateTime.Now, SystemTime.Now);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Now_ShouldReturnSmallDifferInMilliSecondFromMockDateTime()
        {
            var mockDate = new DateTime(2017, 04, 15, 9, 20, 30);
            SystemTime.SetDateTime(mockDate);

            var result = DateTime.Compare(mockDate, SystemTime.Now);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void UtcNow_ShouldBeSameAsDateTimeUtcNow()
        {
            var result = DateTime.Compare(DateTime.UtcNow, SystemTime.UtcNow);
            Assert.AreEqual(0, result);
        }
    }
}
