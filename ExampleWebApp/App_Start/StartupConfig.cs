using System;
using ExampleWebApp;
using ExampleWebApp.Properties;
using MockableDateTime;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(StartupConfig), "Initial")]
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