namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advyteam.tache")]
    public partial class tache
    {
        public int id { get; set; }

        public DateTime? dateDeDebut { get; set; }

        public int? etatActuel { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public double? nombreDheuresEstimes { get; set; }

        public int priorite { get; set; }

        public int? employe_id { get; set; }

        public int? timesheet_id { get; set; }

        public virtual employe employe { get; set; }

        public virtual timesheet timesheet { get; set; }
    }
}
