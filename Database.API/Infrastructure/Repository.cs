using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.API.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContextModel _dbContextModel { get; set; }

        public Repository(DbContextModel dbContextModel)
        {
            _dbContextModel = dbContextModel;
        }

        public  void Add(T entity)
        {
            _dbContextModel.Add(entity);
            _dbContextModel.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContextModel.Set<T>().Remove(entity);
            _dbContextModel.SaveChangesAsync();
        }

        //Task<IEnumerable<T>> GetAll()
        //{
        //   _dbContextModel.Set<T>().ToList();
        //}

        public virtual async Task<T> GetById(int Id)
        {
            return await _dbContextModel.Set<T>().FindAsync(Id);
        }

        public void Update(T entity)
        {
            _dbContextModel.Update(entity);
        }

        void IRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await _dbContextModel.Set<T>().Where(expression).ToListAsync();
        }

       //async void IRepository<T>.GetById(int Id)
       // {
       //     return await _dbContextModel.Set<T>().Find(Id);
       // }

        async void IRepository<T>.Update(T entity)
        {
            _dbContextModel.Entry(entity).State = EntityState.Modified;
            _dbContextModel.Set<T>().Update(entity);
          await  _dbContextModel.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _dbContextModel.Set<T>().Where(expression).ToListAsync();
        }

        async Task<IEnumerable<T>> IRepository<T>.GetAll()
        {
            return await _dbContextModel.Set<T>().ToListAsync();
        }

        async Task<IEnumerable<T>> IRepository<T>.Get(Expression<Func<T, bool>> expression)
        {
           return await _dbContextModel.Set<T>().ToListAsync();
        }

       async  Task<T> IRepository<T>.GetById(int Id)
        {
            return await _dbContextModel.Set<T>().FindAsync(Id);
        }

        //void IRepository<T>.Add(T entity)
        //{
        //    _dbContextModel.Add(entity);
        //     _dbContextModel.SaveChanges();
        //}


    }
}
