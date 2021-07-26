using System;
using System.Collections.Generic;

namespace SplitExpenses.Provider
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SplitExpensesDbContext _splitExpensesDbContext;
        private Dictionary<string, object> repositories; 

        public UnitOfWork(SplitExpensesDbContext splitExpensesDbContext)
        {
            _splitExpensesDbContext = splitExpensesDbContext;
        }

        public void Commit()
        {
            _splitExpensesDbContext.SaveChanges();
        }

        public Repository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _splitExpensesDbContext);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }
    }
}
