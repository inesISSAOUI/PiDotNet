using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.Data;
using Pidev.ServicePattern;

namespace Pidev.Service
{
  public   interface IFormationService : IService<formation>
    {
        //methodes specifique(sans crud!!)
        IEnumerable<formation> GetFormations();/*(string nameCategory);
        IEnumerable<Application> ListProdTrie();
        IEnumerable<Application> DeuxProduit();*/
        //int NbrProduitPourProvider(Provider p, int seuil);

    }
}
