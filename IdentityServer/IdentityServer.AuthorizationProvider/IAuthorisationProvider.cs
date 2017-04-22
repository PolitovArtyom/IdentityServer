using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider
{
    public interface IAuthorisationProvider : IDisposable
    {
        void Initialize(IDictionary<string, string> parameters, ILogger log);
        Task<Result> Authorize(string user, string password);
    }
}