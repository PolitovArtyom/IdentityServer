using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider
{
    public interface IRegistrationProvider : IAuthorisationProvider
    {
        //TODO IRegistrationProvider should not inherites from IAuthorisationProvider 
        Task<Result> Register(string user, string password);
    }
}