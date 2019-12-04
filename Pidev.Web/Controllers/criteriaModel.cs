namespace Advyteam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class criteriaModel
    {

        [Key]
        public int idCriteria { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string description { get; set; }

    }
}
