using System;

namespace MockableDateTime
{
    public static class SystemTime
    {
        public static DateTime Now => GetNow();
        public static DateTime Today => GetNow().Date;
        public static DateTime UtcNow => GetUtcNow();

        internal static TimeSpan DateTimeOffset = TimeSpan.Zero;
        internal static Func<DateTime> GetNow = () => DateTime.Now + DateTimeOffset;
        internal static Func<DateTime> GetUtcNow = () => DateTime.UtcNow + DateTimeOffset;

        /// <summary>
        /// This method should be called when application started for setting specific system date time.
        /// </summary>
        /// <param name="specificDateTime"></param>
        public static void SetDateTime(DateTime specificDateTime)
        {
            DateTimeOffset = specificDateTime - DateTime.Now;
        }

        /// <summary>
        /// This method should be called in Unit Test TearDown. 
        /// </summary>
        public static void ResetDateTime()
        {
            DateTimeOffset = TimeSpan.Zero;
        }
    }
}
