using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Server.Common.Authentication
{
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public object ModuleContext { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
