using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Database.API.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);

        Task<T> GetById(int Id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
