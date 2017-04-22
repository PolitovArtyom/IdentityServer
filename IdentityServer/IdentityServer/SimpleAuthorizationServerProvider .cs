using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.AuthorizationProvider;
using Microsoft.Owin.Security.OAuth;

namespace IdentityServer
{
    public class OauthAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private IAuthorisationProvider _authProvider;
        public OauthAuthorizationProvider(IAuthorisationProvider provider) : base()
        {
            _authProvider = provider;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var authResult = await _authProvider.Authorize(context.UserName, context.Password);
            if (authResult.Success == false)
            {
                context.SetError("invalid_grant", authResult.Message);
                return;
            }
              
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            //TODO privder role mapping
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}