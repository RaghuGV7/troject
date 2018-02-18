using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Data;
using Trogsoft.Project.Server.Common.Authentication;
using BCrypt.Net;

namespace Trogsoft.Project.Server.Authentication
{
    public class InternalAuthModule : IAuthenticationModule
    {
        public AuthenticatedUser Authenticate(string username, string password, long? organisation = 0)
        {
            using (var db = new ProjectEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.Username == username);
                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        return new AuthenticatedUser
                        {
                            User = Mapper.Map<Project.Common.User>(user),
                            Status = AuthenticationStatus.Success
                        };
                    }
                    else
                    {
                        return new AuthenticatedUser
                        {
                            Status = AuthenticationStatus.BadPassword,
                            User = Mapper.Map<Project.Common.User>(user)
                        };
                    }
                }
                else
                {
                    return new AuthenticatedUser
                    {
                        Status = AuthenticationStatus.UserNotFound
                    };
                }
            }
        }
    }
}
