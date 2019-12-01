namespace Pidev.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.planification")]
    public partial class planification
    {
        public int id { get; set; }

        [StringLength(255)]
        public string dateDebut { get; set; }

        [StringLength(255)]
        public string dateFin { get; set; }

        public int numberP { get; set; }

        public int? idFormateur { get; set; }

        public int? idFormation { get; set; }

        public virtual formateur formateur { get; set; }

        public virtual formation formation { get; set; }
    }
}
