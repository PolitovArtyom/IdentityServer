using System.Collections.Generic;

namespace IdentityServer.AuthorizationProvider
{
    public class Result
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public IEnumerable<Right> Rights { get; set; } = new List<Right>();
    }
}