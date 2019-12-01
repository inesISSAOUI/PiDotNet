using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.Domaine.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        // public int Question_Value { get; set; }
        public String QuestionDescription { get; set; }
        public String Question1stSuggestion { get; set; }
        public String Question2ndSuggestion { get; set; }
        public String Question3rdSuggestion { get; set; }
        public String QuestionCorrectAnswer { get; set; }
    }
}
