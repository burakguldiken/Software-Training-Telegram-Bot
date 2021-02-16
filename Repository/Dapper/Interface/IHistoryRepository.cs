using SoftwareTraining.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Repository.Dapper.Interface
{
    public interface IHistoryRepository
    {
        long InsertHistory(History history);
    }
}
