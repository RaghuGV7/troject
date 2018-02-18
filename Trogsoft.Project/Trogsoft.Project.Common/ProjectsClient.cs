namespace Trogsoft.Project.Common
{
    public class ProjectsClient
    {
        private AuthToken token;
        private ProjectClient projectClient;

        internal ProjectsClient(AuthToken token, ProjectClient projectClient)
        {
            this.token = token;
            this.projectClient = projectClient;
        }
    }
}