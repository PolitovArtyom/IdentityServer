using System;
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
        private IAuthorisationProvider _authorisationProvider;
        private bool _initialized;
        private readonly AuthProviderConfiguration _config;

        public IAuthorisationProvider AuthProvider
        {
            get
            {
                if (_initialized == false)
                    Initialize();
                return _authorisationProvider;
            }
        }


        public IRegistrationProvider RegistrationProvider
        {
            get
            {
                if (_initialized == false)
                    Initialize();
                return _authorisationProvider as IRegistrationProvider;
            }
        }


        public ProviderBuilder(AuthProviderConfiguration config)
        {
            _config = config;
        }

        private void Initialize()
        {
            _authorisationProvider = Build(_config.AssemblyPath);
            var log = new NlogAdapter(LogManager.GetLogger("ProviderLog"));

            _authorisationProvider.Initialize(_config.Parameters, log);

            _initialized = true;
        }

        private IAuthorisationProvider Build(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
                throw new FileNotFoundException($"Provider library {assemblyPath} not found");

            var assembly = Assembly.LoadFrom(assemblyPath);
            var provider =
                assembly.GetTypes().Where(type => typeof(IRegistrationProvider).IsAssignableFrom(type)).ToList();
            if (provider.Count() == 0)
                provider =
                    assembly.GetTypes().Where(type => typeof(IAuthorisationProvider).IsAssignableFrom(type)).ToList();


            var providerInstance = (IAuthorisationProvider) Activator.CreateInstance(provider.Single());
            return providerInstance;
        }

        public void Dispose()
        {
            _authorisationProvider?.Dispose();
        }
    }
}

