namespace Advyteam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.employee")]
    public class employee
    {
        public employee()
        {

        }
        
        [Key]
        public int idEmployee { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public virtual ICollection<assessment> assessment { get; set; }


    }
}
