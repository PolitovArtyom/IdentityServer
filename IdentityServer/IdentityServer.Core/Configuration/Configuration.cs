using System;
using System.Configuration;
using System.Linq;

namespace IdentityServer.Core.Configuration
{
    public class Configuration
    {
        public TimeSpan TokenPeriod { get; set; } = TimeSpan.FromMinutes(value: 5);

        public AuthProviderConfiguration AuthProviderConfiguration { get; set; }

        public static Configuration Read()
        {
            var config = new Configuration();
            if (
                ConfigurationManager.AppSettings.AllKeys.Any(
                    a => a.Equals("TokenPeriod", StringComparison.OrdinalIgnoreCase)))
            {
                int minutes;
                if (int.TryParse(ConfigurationManager.AppSettings["TokenPeriod"], out minutes))
                    config.TokenPeriod = TimeSpan.FromMinutes(minutes);
            }

            var providersSection = (ProviderSettingsSection) ConfigurationManager.GetSection("providerSettings");
            config.AuthProviderConfiguration = providersSection.Read();
            return config;
        }
    }
}
