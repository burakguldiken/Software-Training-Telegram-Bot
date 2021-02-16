using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Repository.Dapper.Interface
{
    public interface IBaseRepository
    {
        T GetByID<T>(long _ID) where T : class, new();
        IEnumerable<T> GetList<T>(params object[] _Values) where T : class, new();
        long Insert<T>(T _Item) where T : class, new();
        bool Update<T>(T _Item) where T : class, new();
        bool Delete<T>(T _Item) where T : class, new();
        IEnumerable<T> ExecuteCommand<T>(string _Command, params object[] _Values);
        IEnumerable<T> ExecuteCommand<T>(string _Command);
        bool BulkInsert<T>(List<T> _Item) where T : class, new();
        bool BulkUpdate<T>(List<T> _Item) where T : class, new();
        bool BulkDelete<T>(List<T> _Item) where T : class, new();
    }
}
