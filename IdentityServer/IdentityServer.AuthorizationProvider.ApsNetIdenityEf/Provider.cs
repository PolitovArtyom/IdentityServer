using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider.ApsNetIdenityEf
{
    public class Provider : IRegistrationProvider
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Initialize(IDictionary<string, string> parameters, ILogger log)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Authorize(string user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Register(string user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
