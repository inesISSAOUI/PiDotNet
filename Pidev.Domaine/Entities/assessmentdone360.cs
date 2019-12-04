namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assessmentdone360")]
    public partial class assessmentdone360
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public assessmentdone360()
        {
            criteriascore = new HashSet<criteriascore>();
        }

        [Key]
        public int idDone360 { get; set; }

        public int coWorkerScore { get; set; }

        public int? assessment360_id360 { get; set; }

        public int? coWorker_idEmployee { get; set; }

        public virtual assessment360 assessment360 { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<criteriascore> criteriascore { get; set; }
    }
}
