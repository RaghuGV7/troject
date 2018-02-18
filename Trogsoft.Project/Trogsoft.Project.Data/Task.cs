namespace Trogsoft.Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            Contents = new HashSet<Content>();
            Task1 = new HashSet<Task>();
            Timings = new HashSet<Timing>();
            Users = new HashSet<User>();
            Tags = new HashSet<Tag>();
            Users1 = new HashSet<User>();
        }

        public long Id { get; set; }

        public long? ProjectId { get; set; }

        public long? IterationId { get; set; }

        public long? StatusId { get; set; }

        public long? ParentId { get; set; }

        [Required]
        public string Title { get; set; }

        public long Owner { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        public long? PriorityId { get; set; }

        public string TaskType { get; set; }

        public bool IsTouched { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }

        public virtual Iteration Iteration { get; set; }

        public virtual Priority Priority { get; set; }

        public virtual Project Project { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task1 { get; set; }

        public virtual Task Task2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timing> Timings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users1 { get; set; }
    }
}
