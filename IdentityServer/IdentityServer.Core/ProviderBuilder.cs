using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Core.Configuration;
using NLog;

namespace IdentityServer.Core
{
    public class ProviderBuilder : IDisposable
    {
        private readonly IAuthorisationProvider _authorisationProvider;

        public ProviderBuilder(AuthProviderConfiguration config)
        {
            _authorisationProvider = Build(config.AssemblyPath);
            var log = new NlogAdapter(LogManager.GetLogger("ProviderLog"));

            _authorisationProvider.Initialize(config.Parameters, log);
        }

        private IAuthorisationProvider Build(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
                throw new FileNotFoundException($"Provider library {assemblyPath} not found");

            var assembly = Assembly.LoadFile(assemblyPath);
            var provider =
                assembly.GetTypes().Where(a => typeof(IRegistrationProvider).IsAssignableFrom(a) && !a.IsAbstract);
            if (provider.Count() != 0)
                provider =
                    assembly.GetTypes().Where(a => typeof(IAuthorisationProvider).IsAssignableFrom(a) && !a.IsAbstract);

            var providerInstance = (IAuthorisationProvider) Activator.CreateInstance(provider.Single());
            return providerInstance;
        }

        public IAuthorisationProvider GetAuthProvider()
        {
            return _authorisationProvider;
        }

        public IRegistrationProvider GetRegistrationProvider()
        {
            return _authorisationProvider as IRegistrationProvider;
        }

        public void Dispose()
        {
            _authorisationProvider?.Dispose();
        }
    }
}

