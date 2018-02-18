using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Common
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public long? OrganisationId { get; set; }
        public string EmailAddress { get; set; }
        public Organisation Organisation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
