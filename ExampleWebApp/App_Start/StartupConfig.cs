using System;
using ExampleWebApp.Properties;
using MockableDateTime;

namespace ExampleWebApp
{
    public class StartupConfig
    {
        public static void Initial()
        {
            var systemStartupTime = Settings.Default.SystemStartupTime;
            if (systemStartupTime != DateTime.MinValue)
            {
                SystemTime.SetDateTime(systemStartupTime);
            }
        }
    }
}