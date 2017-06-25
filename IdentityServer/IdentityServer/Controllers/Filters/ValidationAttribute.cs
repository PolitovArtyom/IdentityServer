using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers.Filters
{
    public class ValidationAttribute : ValidateInputAttribute
    {
        public ValidationAttribute(bool enableValidation = true) : base(enableValidation)
        {
            if (enableValidation)
            {
                //TODO implement validationva
            }

        }
    }
}