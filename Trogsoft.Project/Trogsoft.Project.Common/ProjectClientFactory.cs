using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Common
{
    public static class ProjectClientFactory
    {

        static ConcurrentDictionary<string, ProjectClient> clients = new ConcurrentDictionary<string, ProjectClient>();

        public static ProjectClient GetClient(AuthToken token)
        {
            ProjectClient client;
            if (clients.TryGetValue(token.Raw, out client))
            {
                return client;
            }
            else
            {
                client = new ProjectClient(token);
                clients.TryAdd(token.Raw, client);
                return client;
            }
        }

    }
}
