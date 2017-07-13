namespace IdentityServer.AuthorizationProvider.TestProvider.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
