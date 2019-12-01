namespace Pidev.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.formateur")]
    public partial class formateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formateur()
        {
            planification = new HashSet<planification>();
        }

        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool? disponibilite { get; set; }

        [Column(TypeName = "tinyblob")]
        public byte[] formateurs { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int number { get; set; }

        [StringLength(255)]
        public string specialite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planification> planification { get; set; }
    }
}
