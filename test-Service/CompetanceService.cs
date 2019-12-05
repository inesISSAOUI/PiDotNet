using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_data;
using test_data.Infrastructure;
using test_ServicePattern;
namespace test_Service
{
   public class CompetanceService : Service<Competance>, ICompetanceService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public CompetanceService():base(UOW)
        {

        }
    }
}
