using System;

namespace Trogsoft.Project.Common
{
    public class Iteration
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}