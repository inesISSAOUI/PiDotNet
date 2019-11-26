namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advyteam.notification")]
    public partial class notification
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? employe_id { get; set; }

        public virtual employe employe { get; set; }
    }
}
