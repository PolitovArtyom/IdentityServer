using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        [Required]
        public ProviderRight Right { get; set; } 
    }
}
