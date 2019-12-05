using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_data;
using test_data.Infrastructure;
using test_ServicePattern;
namespace test_Service
{
    public class EmployeService : Service<employe>, IEmployeService
    {
        private Context db = new Context();

        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
       public EmployeService() :base(UOW) { }

        public IEnumerable<employe> GetAllWith()
        {


            return db.employes.Include(e => e.fichemetier).Include(e => e.matricecomp);
        }
    }
    
}
