using System;
using IdentityServer.Data.Repositories;
using Microsoft.Owin.Security;

namespace IdentityServer.TokenProvider.Jwt
{
    public class JwtFormatter : ISecureDataFormat<AuthenticationTicket>
    {
        //TODO not forget to add nuget references at Owin
        private readonly ITokenProvider _tokenProvider;
        private readonly ClientsRepository _clientsRepository;
        private const string ClientPropertyKey = "audience";

        public JwtFormatter(ITokenProvider tokenProvider, ClientsRepository clientsRepository)
        {
            _tokenProvider = tokenProvider;
            _clientsRepository = clientsRepository;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            string clientId;
            if (data.Properties.Dictionary.ContainsKey(ClientPropertyKey))
                clientId = data.Properties.Dictionary[ClientPropertyKey];
            else
                throw new ArgumentNullException($"Parameter {ClientPropertyKey} not found in token request");

            var client = _clientsRepository.Get(clientId).Result;

            return _tokenProvider.Generate(client, data.Identity);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}