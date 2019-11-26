namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advyteam.travailparjour")]
    public partial class travailparjour
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Jour { get; set; }

        public double? nombreDHeureTravaille { get; set; }

        public int? employe_id { get; set; }

        public int? timesheet_id { get; set; }

        public virtual employe employe { get; set; }

        public virtual timesheet timesheet { get; set; }
    }
}
