using System.Collections.Generic;

namespace IdentityServer.AuthorizationProvider
{
    public class Result
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public IEnumerable<Role> Roles { get; set; } = new List<Role>();
    }
}