using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.AuthorizationProvider;
using Microsoft.Owin.Security.OAuth;

namespace IdentityServer
{
    public class OauthAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private IAuthorisationProvider _provider;

        public OauthAuthorizationProvider(IAuthorisationProvider provider)
        {
            _provider = provider;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var authResult = await _provider.Authorize(context.UserName, context.Password);
            if (authResult.Success == false)
            {
                context.SetError("invalid_grant", authResult.Message);
                return;
            }
              
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            //TODO provider role mapping
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}