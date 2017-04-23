using System.Collections.Generic;

namespace IdentityServer.Core.Configuration
{
    public class AuthProviderConfiguration
    {
        public string AssemblyPath { get; set; }

        public IDictionary<string,string> Parameters{ get; set; }
    }
}