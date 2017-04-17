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
       
        public virtual Client Client { get; set; }

        public ICollection<ResourceRight> Rights { get; set; } = new List<ResourceRight>();
    }
}
