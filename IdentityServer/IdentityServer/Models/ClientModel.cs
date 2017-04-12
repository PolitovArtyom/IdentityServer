using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdentityServer.Data.Models;

namespace IdentityServer.Models
{
    internal class ClientModel
    {
        public ClientModel()
        {
            ClientRoles = new List<Role>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Не заполнено поле *Клиент*")]
        [Display(Name = "Клиент")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не заполнено поле *Идентификатор*")]
        [Display(Name = "Идентификатор")]
        public string Identifier { get; set; }

        [Required(ErrorMessage = "Не заполнено поле *Секрет*")]
        [Display(Name = "Секрет")]
        public string Secret { get; set; }

        [Required(ErrorMessage = "Не заполнено поле *Адрес возврата*")]
        [Display(Name = "Адрес возврата")]
        public string Callback { get; set; }

        [Display(Name = "Описание клиента")]
        public string Description { get; set; }

        [Display(Name = "Адрес, на который происходит редирект при логауте")]
        public string LogoutPage { get; set; }

        public List<Role> ClientRoles { get; set; }
    }
}