namespace test_data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.niveauxfiche")]
    public partial class niveauxfiche
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idComp { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idFiche { get; set; }

        public int Niveaux { get; set; }

        public virtual Competance competance { get; set; }

        public virtual fichemetier fichemetier { get; set; }
    }
}
