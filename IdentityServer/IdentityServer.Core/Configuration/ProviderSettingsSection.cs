using System;
using System.Collections.Generic;
using System.Configuration;

namespace IdentityServer.Core.Configuration
{
    public class ProviderSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("assemblyPath", IsRequired = true)]
        public string Path  => (string) base["assemblyPath"];

        [ConfigurationProperty("params")]
        public KeyValueConfigurationCollection Params
            => (KeyValueConfigurationCollection) base["params"];

        public AuthProviderConfiguration Read()
        {
            var dictionary = new Dictionary<string, string>(Params.Count, StringComparer.OrdinalIgnoreCase);
            foreach (KeyValueConfigurationElement element in Params)
                dictionary.Add(element.Key, element.Value);

            return new AuthProviderConfiguration
            {
                AssemblyPath = Path,
                Parameters = dictionary
            };
        }

    }
}
