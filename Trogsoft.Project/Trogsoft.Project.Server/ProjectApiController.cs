using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using Trogsoft.Project.Common;
using Trogsoft.Project.Server.Common.Repository;

namespace Trogsoft.Project.Server
{
    public class ProjectApiController : ApiController
    {
        private const string TokenHeaderName = "X-Auth-Token";

        public AuthToken AuthToken
        {
            get
            {
                if (Request.Headers.Contains(TokenHeaderName))
                {
                    var values = Request.Headers.GetValues(TokenHeaderName);
                    if (values.Any())
                    {
                        AuthToken at = new AuthToken(values.First());
                        return at;
                    }
                }
                return null;
            }
        }

    }

    public class ProjectApiController<T> : ProjectApiController where T: AuthenticatedRepository
    {

        protected TResult callRepository<TResult>(Expression<Func<T, object>> method)
        {
            var repo = (T)Activator.CreateInstance(typeof(T), AuthToken);
            var m = method.Compile();
            var res = m.Invoke(repo);
            return (TResult)res;
        }

    }

}