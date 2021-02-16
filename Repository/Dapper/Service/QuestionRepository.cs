using SoftwareTraining.Entity;
using SoftwareTraining.Repository.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareTraining.Repository.Dapper.Service
{
    public class QuestionRepository : IQuestionRepository
    {
        IBaseRepository dbContext;

        public QuestionRepository(IBaseRepository dbContext)
        {
            this.dbContext = dbContext;
        }

        public Question GetRandomQuestion(int categoryId)
        {
            string sql = @"SELECT * FROM question WHERE categoryId = @categoryId ORDER BY RAND() LIMIT 1;";
            return dbContext.ExecuteCommand<Question>(sql,categoryId).FirstOrDefault();
        }
    }
}
