namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.criteriascore")]
    public partial class criteriascore
    {
        [Key]
        public int idCriteraScore { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public int score { get; set; }

        public int? assessmentDone_idDone360 { get; set; }

        public int? criteria_idCriteria { get; set; }

        public virtual assessmentdone360 assessmentdone360 { get; set; }

        public virtual criteria criteria { get; set; }
    }
}
