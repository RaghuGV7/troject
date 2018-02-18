namespace Trogsoft.Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Timing")]
    public partial class Timing
    {
        public long Id { get; set; }

        public long? TaskId { get; set; }

        public int? TimingType { get; set; }

        public int? Value { get; set; }

        public virtual Task Task { get; set; }
    }
}
