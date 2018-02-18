namespace Trogsoft.Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Setting")]
    public partial class Setting
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }
    }
}
