using Autofac;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Core.Configuration;

namespace IdentityServer
{
    public class IocConfug
    {

        public void Setup()
        {
            var builder = new ContainerBuilder();
            var configuration = new Configuration();
          //  var provider = builder.RegisterType<IAuthorisationProvider>
        }
        
    }
}
