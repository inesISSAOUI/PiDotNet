namespace Advyteam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assessmentself")]
    public class assessmentself
    {
        

        public assessmentself()
        {
            //criteriascoreself = new HashSet<criteriascoreself>();
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

        //public virtual ICollection<criteriascoreself> criteriascoreself { get; set; }
    }
}
