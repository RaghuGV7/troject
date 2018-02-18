namespace Trogsoft.Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public long Id { get; set; }

        public long? TaskId { get; set; }

        public int? ContentType { get; set; }

        public long? Owner { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }

        public string Value { get; set; }

        public string StructureType { get; set; }

        public bool IsNotifyComplete { get; set; }

        public virtual Task Task { get; set; }
    }
}
