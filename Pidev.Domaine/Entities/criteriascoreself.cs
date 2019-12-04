namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.criteriascoreself")]
    public partial class criteriascoreself
    {
        [Key]
        public int idCriteraScore { get; set; }

        [Column(TypeName = "bit")]
        public bool agreed { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public int score { get; set; }

        public int? assessmentSelfDone_idSelf { get; set; }

        public int? criteria_idCriteria { get; set; }

        public virtual assessmentself assessmentself { get; set; }

        public virtual criteria criteria { get; set; }
    }
}
