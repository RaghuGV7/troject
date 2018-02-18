using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Common;
using Trogsoft.Project.Common.Exceptions;
using Trogsoft.Project.Data;
using Trogsoft.Project.Server.Common.Authentication;
using Trogsoft.Project.Server.Common.Repository;

namespace Trogsoft.Project.Server
{
    public class UserRepository : AuthenticatedRepository, IDisposable
    {

        private static List<Type> authModules = new List<Type>();

        public UserRepository(AuthToken token) : base(token)
        {
        }

        static UserRepository()
        {
            using (var db = new ProjectEntities())
            {
                foreach (var module in db.AuthModules.OrderBy(x => x.Ordinal))
                {
                    var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes().Where(y => typeof(IAuthenticationModule).IsAssignableFrom(y) && !y.IsAbstract && !y.IsInterface && y.IsPublic && y.Name == module.Name)).FirstOrDefault();
                    if (type != null)
                    {
                        authModules.Add(type);
                    }
                }
            }
        }

        public AuthToken Authenticate(string username, string password, long? organisation = 0)
        {

            List<Type> modules = new List<Type>();

            using (var db = new ProjectEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.Username == username);
                if (user != null)
                {
                    var module = user.AuthModule.Name;
                    modules.Add(authModules.SingleOrDefault(x => x.Name == module));
                }
                else
                {
                    modules.AddRange(authModules);
                }
            }

            foreach (var type in modules)
            {
                var module = (IAuthenticationModule)Activator.CreateInstance(type);
                var result = module.Authenticate(username, password, organisation);
                if (result != null && result.Status == AuthenticationStatus.Success)
                {
                    using (var db = new ProjectEntities())
                    {
                        Data.User user = null;
                        if (result.User != null && result.User.Id > 0)
                        {
                            user = db.Users.SingleOrDefault(x => x.Id == result.User.Id);
                        }

                        if (user == null && result.UserData != null)
                        {
                            user = db.Users.SingleOrDefault(x => x.EmailAddress == result.UserData.EmailAddress && x.Username == result.UserData.Username);
                        }

                        if (user == null)
                        {
                            user = new Data.User
                            {
                                Username = username,
                                EmailAddress = "none@example.com"
                            };
                            db.Users.Add(user);
                        }

                        if (result.UserData != null)
                        {
                            user.Password = result.UserData.Password;
                            user.EmailAddress = result.UserData.EmailAddress ?? "none@example.com";
                            user.Username = result.UserData.Username;
                            user.ModuleContext = JsonConvert.SerializeObject(result.UserData.ModuleContext ?? "");
                            user.AuthModuleId = db.AuthModules.SingleOrDefault(x => x.Name == type.Name).Id;
                            user.FirstName = result.UserData.FirstName;
                            user.LastName = result.UserData.LastName;
                            user.DisplayName = result.UserData.DisplayName;
                        };

                        db.SaveChanges();

                        var token = TokenHelper.Create(Mapper.Map<Project.Common.User>(user));
                        return token;

                    }
                }
            }

            // Failed all attempts
            throw new UserNotFoundException();

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
