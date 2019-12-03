using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.Domaine.Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int FormationId { get; set; }
        //public int CompnayId { get; set; }
        //public int CandidatId { get; set; }
        // public int Max_Score { get; set; }
        public int Score { get; set; }
        public String Type { get; set; }

        public virtual ICollection<Question> Questions
        {
            get; set;
        }
    }
}
