using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Common
{
    public class Project
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public DateTime Created { get; set; }
        public long? OrganisationId { get; set; }
        public IEnumerable<Iteration> Iterations { get; set; }
    }
}
