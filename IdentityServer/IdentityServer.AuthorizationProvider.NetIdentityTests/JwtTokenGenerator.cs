using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Owin.Security;
using SigningCredentials = Microsoft.IdentityModel.Tokens.SigningCredentials;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;

namespace IdentityServer.AuthorizationProvider.NetIdentityTests
{
    public class JwtTokenGenerator : ISecureDataFormat<AuthenticationTicket>
    {
        private const string AudiencePropertyKey = "audience";


     
        private readonly string _issuer = string.Empty;

        public JwtTokenGenerator(string issuer)
        {
            _issuer = issuer;
          //  _clients = clients;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            var clientId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
                ? data.Properties.Dictionary[AudiencePropertyKey]
                : null;

            if (string.IsNullOrWhiteSpace(clientId))
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");

          //  Client client = _clients.Get(clientId);
            var securityKey = System.Text.Encoding.Unicode.GetBytes("5A0AB091-3F84-4EC4-B227-0834FCD8B1B4");
            var inMemorySymmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            var signatureAlgorithm = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
            var digestAlgorithm = "http://www.w3.org/2001/04/xmlenc#sha256";
          
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
           
            var creds = new SigningCredentials(inMemorySymmetricSecurityKey, signatureAlgorithm);
            var token = new JwtSecurityToken(_issuer, clientId, data.Identity.Claims, issued.Value.UtcDateTime,
                expires.Value.UtcDateTime, creds);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}
