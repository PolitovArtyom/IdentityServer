using System;
using System.Collections.Generic;
using System.Configuration;

namespace IdentityServer.Core.Configuration
{
    public class ProviderSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("assemblyPath", IsRequired = true)]
        public string Path => (string) base["path"];

        [ConfigurationProperty("providerSettings")]
        public KeyValueConfigurationCollection ProviderSettings
            => (KeyValueConfigurationCollection) base["providerSettings"];

        public Configuration ReadConfiguration()
        {
            var dictionary = new Dictionary<string, string>(ProviderSettings.Count, StringComparer.OrdinalIgnoreCase);
            foreach (KeyValueConfigurationElement element in ProviderSettings)
                dictionary.Add(element.Key, element.Value);

            return new Configuration
            {
                AuthProviderConfiguration = new AuthProviderConfiguration
                {
                    AssemblyPath = Path,
                    Parameters = dictionary
                }
            };
        }

    }
}
