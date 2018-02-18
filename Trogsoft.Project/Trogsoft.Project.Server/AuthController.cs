using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Trogsoft.Project.Common;
using Trogsoft.Project.Data;

namespace Trogsoft.Project.Server
{
    public class AuthController : ProjectApiController<UserRepository>
    {

        [HttpPost]
        public AuthToken Authenticate(AuthenticationModel model) => callRepository<AuthToken>(x => x.Authenticate(model.Username, model.Password, model.OrganisationId));

    }
}
