using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Server.Common.Authentication;

namespace Trogsoft.Project.Server.Authentication
{
    public class ActiveDirectoryAuthModule : IAuthenticationModule
    {
        public AuthenticatedUser Authenticate(string username, string password, long? organisation = 0)
        {
            // create a "principal context" - e.g. your domain (could be machine, too)
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
            {
                // find the user
                var up = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, username);
                if (up != null)
                {
                    // validate the credentials
                    bool isValid = pc.ValidateCredentials(username, password);

                    if (isValid)
                    {
                        return new AuthenticatedUser
                        {
                            Status = AuthenticationStatus.Success,
                            UserData = new UserData
                            {
                                EmailAddress = up.EmailAddress,
                                Username = up.SamAccountName,
                                Password = null,
                                DisplayName = up.DisplayName,
                                FirstName = up.GivenName,
                                LastName = up.Surname,
                                ModuleContext = new
                                {
                                    Sid = up.Sid.ToString()
                                }
                            }
                        };
                    }

                }

                return new AuthenticatedUser
                {
                    Status = AuthenticationStatus.UserNotFound
                };

            }
        }
    }
}
