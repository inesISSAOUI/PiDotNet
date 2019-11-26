namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advyteam.bonpoint")]
    public partial class bonpoint
    {
        public int id { get; set; }

        public DateTime? date { get; set; }

        public int? type { get; set; }

        public int? employe_id { get; set; }

        public virtual employe employe { get; set; }
    }
}
