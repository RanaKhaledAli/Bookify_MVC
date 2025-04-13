using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.DataAcess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T-Category
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        //
        //Category? categoryFromDb1 = _dbContext.Categories.FirstOrDefault(c => c.Id == id)
        T Get(Expression<Func<T, bool>> ?predicate, string? includeProperties = null,bool tracked=false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
