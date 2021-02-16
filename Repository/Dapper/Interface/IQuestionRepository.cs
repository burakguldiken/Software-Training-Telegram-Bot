using SoftwareTraining.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Repository.Dapper.Interface
{
    public interface IQuestionRepository
    {
        public Question GetRandomQuestion(int categoryId);
    }
}
