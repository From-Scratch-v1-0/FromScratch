using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Services.Contracts
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GeAll();
        T GetById(int id);
        IEnumerable<T> GetByCondition(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
