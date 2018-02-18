using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Data
{
    [Table("AuthModule")]
    public class AuthModule
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ModulePath { get; set; }

        [Required]
        public int Ordinal { get; set; }

    }
}
