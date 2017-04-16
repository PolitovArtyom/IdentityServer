using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class RoleDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ClientId { get; set; }

        public int RightId { get; set; }
    }
}