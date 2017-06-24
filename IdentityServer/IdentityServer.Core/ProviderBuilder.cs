using System;
using System.IO;
using System.Linq;
using System.Reflection;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Core.Configuration;
using NLog;
using ILogger = IdentityServer.AuthorizationProvider.ILogger;

namespace IdentityServer.Core
{
    public class ProviderBuilder : IDisposable
    {
        private IAuthorisationProvider _authorisationProvider;
        private IRegistrationProvider _registrationProvider;
        private bool _initialized;
        private readonly AuthProviderConfiguration _config;
        private readonly ILogger _log;

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
                return _registrationProvider;
            }
        }


        public ProviderBuilder(AuthProviderConfiguration config, ILogger providerLog)
        {
            _config = config;
            _log = providerLog;
        }

        private void Initialize()
        {
            _authorisationProvider = Build(_config.AssemblyPath);

            _authorisationProvider.Initialize(_config.Parameters, _log);

            _registrationProvider = _authorisationProvider as IRegistrationProvider;
            _initialized = true;
        }

        private IAuthorisationProvider Build(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
                throw new FileNotFoundException($"Provider library {assemblyPath} not found");

            var assembly = Assembly.LoadFrom(assemblyPath);
            var provider =
                assembly.GetTypes().Where(type => typeof(IRegistrationProvider).IsAssignableFrom(type)).ToList();
            if (!provider.Any())
                provider =
                    assembly.GetTypes().Where(type => typeof(IAuthorisationProvider).IsAssignableFrom(type)).ToList();

            var providerInstance = (IAuthorisationProvider) Activator.CreateInstance(provider.Single());
            return providerInstance;
        }

        public void Dispose()
        {
            _authorisationProvider?.Dispose();
            _registrationProvider?.Dispose();
        }
    }
}

