using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Core;
using IdentityServer.Core.Configuration;
using IdentityServer.Data.Repositories;
using IdentityServer.TokenProvider;
using IdentityServer.TokenProvider.Jwt;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace IdentityServer
{
    public static class IocConfug
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            var providerBuilder = new ProviderBuilder(Configuration.Read().AuthProviderConfiguration, new NlogAdapter("providerLog"));

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => providerBuilder.AuthProvider).As<IAuthorisationProvider>();
            builder.Register(c => providerBuilder.RegistrationProvider).As<IRegistrationProvider>();
            builder.RegisterType(typeof(OauthAuthorizationProvider)).As<IOAuthAuthorizationServerProvider>();
            builder.RegisterType(typeof(ClientsRepository)).As<ClientsRepository>();
            builder.RegisterType(typeof(RolesRepository)).As<RolesRepository>();

            builder.RegisterType(typeof(JwtProvider)).As<ITokenProvider>().WithParameter("issuer","test").WithParameter("period", TimeSpan.FromMinutes(1));
            builder.RegisterType(typeof(JwtFormatter)).As<ISecureDataFormat<AuthenticationTicket>>();

            return builder.Build();
        }
    }
}
