using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminApi.Models
{
    public class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private DbContext _db = null;

        private readonly DbSet<T> _entity = null;

        public SqlRepository(AppDbContext db)
        {
            _db = db;
            _entity = db.Set<T>();
        }
        public List<T> SelectAll()
        {
            return _entity.ToList();
        }
        public virtual List<T> SelectAllByClause(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _entity;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }
        public T SelectById(object id)
        {
            return _entity.Find(id);
        }
        public T Insert(T obj)
        {
            _entity.Add(obj);
            _db.SaveChanges();
            return obj;
        }
        public T Update(T obj)
        {
            _entity.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
            return obj;
        }
        public T Delete(object id)
        {
            T existing = _entity.Find(id);
            if (existing != null)
            {
                _entity.Remove(existing);
                _db.SaveChanges();
            }
            return existing;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
