namespace SplitExpenses.Provider
{
    public interface IUnitOfWork
    {
        void Commit();
        Repository<T> Repository<T>() where T : class;
    }
}
