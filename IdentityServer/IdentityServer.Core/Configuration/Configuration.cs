using System.Configuration;

namespace IdentityServer.Core.Configuration
{
    public class Configuration
    {
        public AuthProviderConfiguration AuthProviderConfiguration { get; set; }

        public static Configuration Build()
        {
            var section = (ProviderSettingsSection)ConfigurationManager.GetSection("providerSettings");
            return section.ReadConfiguration();
        }

    }
}
