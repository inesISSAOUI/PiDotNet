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
    public class QuestionService : Service<Question>, IQuestionService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public QuestionService() : base(UTK)
        {

        }


        public IEnumerable<Question> GetQuestions()
        {
            return GetMany();
        }
    }
}
