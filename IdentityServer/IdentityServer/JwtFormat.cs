using IdentityServer.TokenProvider;
using System;
using System.Data.Entity.Core;
using IdentityServer.Data.Models;
using IdentityServer.Data.Repositories;
using Microsoft.Owin.Security;

namespace IdentityServer
{
    public class JwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly ClientsRepository _clientsRepository;
        private const string ClientPropertyKey = "audience";

        public JwtFormat(ITokenProvider tokenProvider, ClientsRepository clientsRepository)
        {
            _tokenProvider = tokenProvider;
            _clientsRepository = clientsRepository;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            string clientId = data.Properties.Dictionary.ContainsKey(ClientPropertyKey) ? data.Properties.Dictionary[ClientPropertyKey] : null;
            Client client = _clientsRepository.Get(clientId);
            if(client == null)
                throw new ObjectNotFoundException($"Client with identifier {clientId} not registered");

            //TODO where put role mapping?
            return _tokenProvider.Generate(client, data.Identity);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}