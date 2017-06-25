using System;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(IdentityServer.Startup))]
namespace IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = IocConfug.GetContainer();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            WebApiConfig.Register(config);
           

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = (IOAuthAuthorizationServerProvider)container.Resolve(typeof(IOAuthAuthorizationServerProvider)),
                AccessTokenFormat = (ISecureDataFormat<AuthenticationTicket>)container.Resolve(typeof(ISecureDataFormat<AuthenticationTicket>)),
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

    }
}