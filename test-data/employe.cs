namespace test_data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.employe")]
    public partial class employe
    {
        public int Id { get; set; }

        [Column(TypeName = "bit")]
        public bool demande { get; set; }

        [StringLength(255)]
        public string grade { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? ficheMetier_Id { get; set; }

        public int? matriceComp_Id { get; set; }

        public virtual fichemetier fichemetier { get; set; }

        public virtual matricecomp matricecomp { get; set; }
    }
}
