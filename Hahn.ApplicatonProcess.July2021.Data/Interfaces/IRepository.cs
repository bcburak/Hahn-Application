using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> ListAllAsync();

        T Add(T entity);

        Task<T> AddAsync(T entity);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void Delete(T entity);

        Task DeleteAsync(T entity);

        IQueryable<T> GetAll();

        Task<T> FindByIdAsync(params object[] keyValues);


        IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "");
    }
}
