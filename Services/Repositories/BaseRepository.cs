using FS_DAL.Context;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Services.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        public BaseRepository(FSContext context)
        {
            Context = context;
        }

        protected FSContext Context { get; set; }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GeAll()
        {
            return Context.Set<T>();
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        } 

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
