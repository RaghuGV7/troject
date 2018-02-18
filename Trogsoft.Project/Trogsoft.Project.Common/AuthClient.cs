using System.Threading.Tasks;

namespace Trogsoft.Project.Common
{
    public class AuthClient
    {
        private AuthToken token;
        private ProjectClient projectClient;

        internal AuthClient(AuthToken token, ProjectClient projectClient)
        {
            this.token = token;
            this.projectClient = projectClient;
        }

        public AuthToken Authenticate(AuthenticationModel model) => projectClient.Post<AuthToken>("api/Auth/Authenticate", model);
        public async Task<AuthToken> AuthenticateAsync(AuthenticationModel model) => await projectClient.PostAsync<AuthToken>("api/Auth/Authenticate", model);

    }
}