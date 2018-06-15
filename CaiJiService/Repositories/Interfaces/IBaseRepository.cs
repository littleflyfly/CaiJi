using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CaiJiService.Repositories.Interfaces
{
    public partial interface IBaseRepository<T> where T : class, new()
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetModel(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
        bool SaveChanges();
    }
}