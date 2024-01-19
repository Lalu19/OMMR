using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminApi.Models
{
    public interface ISqlRepository<T> where T : class
    {
        List<T> SelectAll();
        List<T> SelectAllByClause(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T SelectById(object id);
        T Insert(T obj);
        T Update(T obj);
        T Delete(object id);
    }
}
