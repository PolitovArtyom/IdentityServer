using System.Security.Claims;
using IdentityServer.Data.Models;

namespace IdentityServer.TokenProvider
{
    public interface ITokenProvider
    {
        string Generate(Client client, ClaimsIdentity identity);
    }
}
