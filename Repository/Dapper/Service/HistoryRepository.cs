using SoftwareTraining.Entity;
using SoftwareTraining.Repository.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Repository.Dapper.Service
{
    public class HistoryRepository : IHistoryRepository
    {
        IBaseRepository dbContext;

        public HistoryRepository(IBaseRepository dbContext)
        {
            this.dbContext = dbContext;
        }

        public long InsertHistory(History history)
        {
            return dbContext.Insert(history);
        }
    }
}
