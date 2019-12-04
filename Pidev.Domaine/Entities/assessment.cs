namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assessment")]
    public partial class assessment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public assessment()
        {
            assessmentself = new HashSet<assessmentself>();
            assessment360 = new HashSet<assessment360>();
        }

        [Key]
        public int idAssessment { get; set; }

        [Column(TypeName = "bit")]
        public bool done360 { get; set; }

        [Column(TypeName = "bit")]
        public bool doneSelf { get; set; }

        [StringLength(255)]
        public string resultAssesment { get; set; }

        public int scoreGlobal { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? employee_idEmployee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assessmentself> assessmentself { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assessment360> assessment360 { get; set; }

        public virtual employee employee { get; set; }
    }
}
