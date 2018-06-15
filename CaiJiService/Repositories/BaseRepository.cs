using CaiJi.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CaiJi.API.Repositories
{
    public partial class BaseRepository<T> where T : class, new()
    {
        private CaiJiDBContext dbContext = DbContextFactory.Create();
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }
        public void Update(T t)
        {
            dbContext.Set<T>().AddOrUpdate(t);
        }
        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().FirstOrDefault(whereLambda);
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}