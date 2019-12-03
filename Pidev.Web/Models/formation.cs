using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidev.Web.Models
{
    public class formation
    {
        public int id { get; set; }

       
        public string description { get; set; }

    
        public string duration { get; set; }

        public int nbPlaceDispo { get; set; }

     
        public string nomFormation { get; set; }
    }
}