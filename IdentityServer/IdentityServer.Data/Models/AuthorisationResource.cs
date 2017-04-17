using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Models
{
    public class AuthorisationResource
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ResourceRight> Rights { get; set; }
    }
}
