using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SplitExpenses.Provider
{
    public class Repository<T> where T : class
    {

        private readonly SplitExpensesDbContext _dbContext;
        private readonly DbSet<T> _dbEntity;

        public Repository() { }

        public Repository(SplitExpensesDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbEntity = _dbContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbEntity.ToList();
        }

        public T GetById(int Id)
        {
            return _dbEntity.Find(Id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbEntity.Where(predicate);
            return query;
        }

        public void Insert(T model)
        {
            _dbEntity.Add(model);
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T model = _dbEntity.Find(id);
            _dbEntity.Remove(model);
        }
    }
}
