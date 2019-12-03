using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.Data;
using Pidev.Service;
using Pidev.ServicePattern;
using TestEF.Data;

namespace Pidev.Service
{
    class FormationService
    {
    }
}
public class FormationService : Service<formation>, IFormationService
{

    static IDataBaseFactory Factory = new DataBaseFactory();
    static IUnitOfWork UTK = new UnitOfWork(Factory);
    public FormationService() : base(UTK)
    {

    }


    public IEnumerable<formation> GetFormations()
    {
        return GetMany();
    }
    /*
public IEnumerable<Application> ListProdTrie()
{
return GetAll().OrderByDescending(t => t.Price); ;
}
public IEnumerable<Application> DeuxProduit()
{
var c = GetAll().OrderBy(p => p.Quantity).Take(2);
foreach (var item in c)
{
   Console.WriteLine(" code de produit " + item.ProductId + " Nom de produit" + item.Name);
}
return c;
}

public int NbrProduitPourProvider(Provider prov, int seuil)
{
return prov.Products.Where(prod => prod.Quantity >= seuil).Count();
}

IEnumerable<Application> IApplicationService.GetProductByCategory(string nameCategory)
{
throw new NotImplementedException();
}

IEnumerable<Application> IApplicationService.ListProdTrie()
{
throw new NotImplementedException();
}

IEnumerable<Application> IApplicationService.DeuxProduit()
{
throw new NotImplementedException();
}*/
}



