using Autofac;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Core;
using IdentityServer.Core.Configuration;

namespace IdentityServer
{
    public static class IocConfug
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            var configuration = new Configuration();
            var providerBuilder = new ProviderBuilder(Configuration.Build().AuthProviderConfiguration);
            builder.RegisterInstance(providerBuilder.GetAuthProvider()).As<IAuthorisationProvider>();
            builder.RegisterInstance(providerBuilder.GetRegistrationProvider()).As<IRegistrationProvider>();

            return builder.Build();
        }
    }
}
