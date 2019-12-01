using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.Domaine.Entities;
using Pidev.ServicePattern;
using TestEF.Data;

namespace Pidev.Service
{
    public class QuizService : Service<Quiz>, IQuizService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public QuizService() : base(UTK)
        {

        }


        public IEnumerable<Quiz> GetQuizs()
        {
            return GetMany();
        }
    }
}
