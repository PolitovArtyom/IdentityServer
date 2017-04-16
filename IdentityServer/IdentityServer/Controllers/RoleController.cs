using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace IdentityServer.Controllers
{
    [RoutePrefix("role")]
    public class RoleController : ApiController
    {
        // GET: Role
        public Task<IHttpActionResult> Get(int clientId)
        {
            
        }

    }
}