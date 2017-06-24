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
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int? RightId { get; set; } = null;

        public Role ToModel()
        {
            var model = new Role()
            {
              Id=this.Id,
              Name=this.Name,
              ClientId = ClientId
            };

            if(this.RightId.HasValue)
                model.Right = new ResourceRight() {Id = RightId.Value};
            return model;
        }
    }
}