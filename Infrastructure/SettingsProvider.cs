using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure
{
    public class SettingsProvider
    {
        public SettingsProvider(IConfigurationRoot configuration)
        {
            Protocol = configuration.GetSection("Environment")["Protocol"];
            Host = configuration.GetSection("Environment")["Host"];
        }

        public string Host { get; private set; }
        public string Protocol { get; private set; }
    }
}
