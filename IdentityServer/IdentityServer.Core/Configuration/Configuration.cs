using System.Configuration;

namespace IdentityServer.Core.Configuration
{
    public class Configuration
    {
        public Configuration()
        {
            AuthProviderConfiguration = (AuthProviderConfiguration) ConfigurationManager.GetSection("providerSettings");
        }

        public AuthProviderConfiguration AuthProviderConfiguration { get; set; }
    }
}
