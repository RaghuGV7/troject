namespace Trogsoft.Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApiKey")]
    public partial class ApiKey
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApiKey()
        {
            Privileges = new HashSet<Privilege>();
        }

        public long Id { get; set; }

        public long? OrganisationId { get; set; }

        [Column("ApiKey")]
        public string ApiKey1 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Created { get; set; }

        public virtual Organisation Organisation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Privilege> Privileges { get; set; }
    }
}
