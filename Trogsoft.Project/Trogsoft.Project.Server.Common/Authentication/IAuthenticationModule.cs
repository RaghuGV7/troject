using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Common;

namespace Trogsoft.Project.Server.Common.Authentication
{
    public interface IAuthenticationModule
    {

        AuthenticatedUser Authenticate(string username, string password, long? organisation = 0);

    }
}
