using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure
{
    public static class Configuration
    {
        public const string ScreenshotsDirectory = "Screenshots";
        public const string SettingsFileName = "appsettings.json";

        public static void Create()
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile(SettingsFileName, optional: true, reloadOnChange: true)
                     .Build();

            Settings = new SettingsProvider(configuration);
        }

        public static SettingsProvider Settings { get; private set; }
    }
}
