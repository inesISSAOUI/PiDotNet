namespace Advyteam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assessment")]
    public partial class assessment
    {
        public assessment()
        {
            assessmentself = new HashSet<assessmentself>();
        }

        [Key]
        public int idAssessment { get; set; }

        public bool done360 { get; set; }

        public bool doneSelf { get; set; }

        public string resultAssesment { get; set; }

        public int scoreGlobal { get; set; }

        public string type { get; set; }

        public int? employee_idEmployee { get; set; }

        public virtual ICollection<assessmentself> assessmentself { get; set; }

        [ForeignKey("employee_idEmployee")]
        public virtual employee employee { get; set; }
    }
}
