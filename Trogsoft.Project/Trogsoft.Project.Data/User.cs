namespace Trogsoft.Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Projects = new HashSet<Project>();
            AssignedTasks = new HashSet<Task>();
            Privileges = new HashSet<Privilege>();
            WatchedTasks = new HashSet<Task>();
        }

        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public long? OrganisationId { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public long? AuthModuleId { get; set; }

        public virtual AuthModule AuthModule { get; set; }

        public virtual Organisation Organisation { get; set; }

        public string ModuleContext { get; set; }

        [Required]
        public string FirstName { get; set; } = "Unknown";

        [Required]
        public string LastName { get; set; } = "User";

        [Required]
        public string DisplayName { get; set; } = "Unknown User";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> AssignedTasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Privilege> Privileges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> WatchedTasks { get; set; }
    }
}
