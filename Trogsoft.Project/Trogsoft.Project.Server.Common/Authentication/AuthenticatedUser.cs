using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Common;

namespace Trogsoft.Project.Server.Common.Authentication
{
    public class AuthenticatedUser
    {
        public User User { get; set; }
        public AuthenticationStatus Status { get; set; }
        public UserData UserData { get; set; }
    }
}
