﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.Domaine.Entities;
using Pidev.ServicePattern;

namespace Pidev.Service
{
    public interface IQuestionService : IService<Question>
    {
        IEnumerable<Question> GetQuestions();
    }
}