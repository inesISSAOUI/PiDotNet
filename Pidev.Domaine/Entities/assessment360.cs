namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assessment360")]
    public partial class assessment360
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public assessment360()
        {
            assessmentdone360 = new HashSet<assessmentdone360>();
        }

        [Key]
        public int id360 { get; set; }

        [Column(TypeName = "bit")]
        public bool finalized360 { get; set; }

        public int score360 { get; set; }

        public int? assessment_idAssessment { get; set; }

        public virtual assessment assessment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assessmentdone360> assessmentdone360 { get; set; }
    }
}
