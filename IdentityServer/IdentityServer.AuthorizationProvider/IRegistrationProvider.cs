using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider
{
    public interface IRegistrationProvider : IAuthorisationProvider
    {
        Task<Result> Register(string user, string password);
    }
}