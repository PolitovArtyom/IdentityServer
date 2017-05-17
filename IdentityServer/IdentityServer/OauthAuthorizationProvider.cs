using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Data.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace IdentityServer
{
    public class OauthAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthorisationProvider _provider;
        private readonly ClientsRepository _clientsRepository;

        public OauthAuthorizationProvider(IAuthorisationProvider provider, ClientsRepository clientsRepository)
        {
            _provider = provider;
            _clientsRepository = clientsRepository;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            // string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
                context.TryGetFormCredentials(out clientId, out clientSecret);

            if (clientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }

            if (clientSecret == null)
            {
                context.SetError("invalid_clientSecret", "client_secret is not set");
                return Task.FromResult<object>(null);
            }

            var client = _clientsRepository.Get(context.ClientId);

            if (client == null)
            {
                context.SetError("invalid_clientId", $"Invalid client_id '{context.ClientId}'");
                return Task.FromResult<object>(null);
            }

            if (!client.Secret.Equals(clientSecret))
            {
                context.SetError("invalid_clientSecret", $"Invalid client_secret for client '{context.ClientId}'");
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});

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

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "audience", context.ClientId == null ? string.Empty : context.ClientId
                }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }
    }
}