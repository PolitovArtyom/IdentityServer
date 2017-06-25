using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Data.Models;

namespace IdentityServer.Models
{
    public class ProviderRightDTO
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ProviderRightDTO() { }

        public ProviderRightDTO(ProviderRight model)
        {
            this.Id = model.Identifier;
            this.Name = model.Name;
        }


        public ProviderRightDTO(Right model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
        }

        public ProviderRight ToModel()
        {
            return new ProviderRight()
            {
                Identifier = this.Id,
                Name = this.Name
            };
        }
    }
}