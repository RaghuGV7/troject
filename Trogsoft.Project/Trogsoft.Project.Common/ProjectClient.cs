using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Common
{
    public class ProjectClient : HttpClient
    {

        internal ProjectClient(AuthToken token, string uri = null)
        {
            this.BaseAddress = new Uri(uri ?? "http://localhost:16119/");
            this.DefaultRequestHeaders.Add("X-Auth-Token", token.Raw);

            this.Projects = new ProjectsClient(token, this);
            this.Users = new AuthClient(token, this);
        }

        public ProjectsClient Projects { get; set; }

        public AuthClient Users { get; set; }

        public T Get<T>(string uri)
        {
            return GetAsync<T>(uri).Result;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var result = await this.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<T>().ConfigureAwait(false);
            }
            else
            {
                throw new Exception(await result.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

        public T Post<T>(string uri, object data)
        {
            return PostAsync<T>(uri, data).Result;
        }

        public async Task<T> PostAsync<T>(string uri, object data)
        {
            var result = await this.PostAsJsonAsync(uri, data).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<T>().ConfigureAwait(false);
            } 
            else
            {
                throw new Exception(await result.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

    }
}
