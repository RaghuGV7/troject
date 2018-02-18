using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Common;

namespace Trogsoft.Project.Server.Common.Repository
{
    public class AuthenticatedRepository 
    {

        protected AuthToken Token { get; set; }

        public AuthenticatedRepository(AuthToken token)
        {
            this.Token = token;
        }

    }
}
