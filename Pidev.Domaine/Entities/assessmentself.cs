namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assessmentself")]
    public partial class assessmentself
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public assessmentself()
        {
            criteriascoreself = new HashSet<criteriascoreself>();
        }

        [Key]
        public int idSelf { get; set; }

        [Column(TypeName = "bit")]
        public bool criteriasAgreed { get; set; }

        [Column(TypeName = "bit")]
        public bool finalizedSelf { get; set; }

        public int scoreSelf { get; set; }

        public int? assessment_idAssessment { get; set; }

        public virtual assessment assessment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<criteriascoreself> criteriascoreself { get; set; }
    }
}
