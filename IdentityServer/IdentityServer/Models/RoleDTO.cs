using IdentityServer.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class RoleDTO
    {
        public RoleDTO() { }

        public RoleDTO(Role role)
        {
            this.Id = role.Id;
            this.Name = role.Name;
            this.ClientId = role.ClientId;
            this.RightId = role.Right.Identifier;
        }

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string RightId { get; set; }

        public Role ToModel()
        {
            var model = new Role()
            {
              Id=this.Id,
              Name=this.Name,
              ClientId = ClientId,
              Right = new ProviderRight() { Identifier = RightId }
            };

            return model;
        }
    }
}