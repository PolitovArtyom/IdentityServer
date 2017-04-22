using System.Collections.Generic;

namespace IdentityServer.AuthorizationProvider
{
    public class Result
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}