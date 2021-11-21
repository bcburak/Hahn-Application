using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MainDbContext _dbContext;
        internal DbSet<T> _dbSet;

        public readonly ILogger _logger;

        public Repository(MainDbContext context,ILogger logger)
        {
            this._dbContext = context;
            this._dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public virtual Task<List<T>> ListAllAsync()
        {
            //_dbContext.Database.IsOracle()
            return _dbContext.Set<T>().ToListAsync();
        }
        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return _dbContext.Set<T>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            _dbContext.SaveChanges();

            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }      

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> FindByIdAsync(params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                //    var query =_dbContext.Set<T>().Where(predicate);
                //    var asd = query.ToSql();
                return _dbContext.Set<T>().Where(predicate); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
