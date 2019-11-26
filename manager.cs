namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advyteam.manager")]
    public partial class manager
    {
        public int id { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        public int? equipe_id { get; set; }

        public virtual equipe equipe { get; set; }
    }
}
