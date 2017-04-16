using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Data.Models
{
    public class ResourceRight
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AuthorisationResource Resource { get; set; }
    }
}
