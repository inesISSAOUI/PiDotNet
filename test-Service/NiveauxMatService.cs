using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_data;
using test_ServicePattern;
using test_data.Infrastructure;
namespace test_Service
{
    public class NiveauxMatService : Service<niveauxmat>, INiveauxMatService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public  NiveauxMatService(): base(UOW)
            {}
        public IEnumerable<Competance> GetCompetances(int idmat) {
          
            return GetAll().Where(e => e.idMat== idmat).Select(x=>x.competance) ;
        }
    }
}
