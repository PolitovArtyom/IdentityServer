using System.ComponentModel.DataAnnotations;
using IdentityServer.Data.Models;

namespace IdentityServer.Models
{
    public class ClientDTO
    {
        //TODO DTO models validation and validation attribute on controllers methods
        public ClientDTO()
        {
        }

        public ClientDTO(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Identifier = client.Identifier;
            Secret = client.Secret;
            Callback = client.Callback;
            LogoutPage = client.LogoutPage;
            Description = client.Description;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public string Callback { get; set; }

        public string LogoutPage { get; set; }

        public string Description { get; set; }

        public Client ToModel()
        {
            var model = new Client
            {
                Id = Id,
                Name = Name,
                Identifier = Identifier,
                Secret = Secret,
                Callback = Callback,
                LogoutPage = LogoutPage,
                Description = Description
            };
            return model;
        }
    }
}