namespace BudgetApp.Interfaces
{
    public interface IRepo<T,TT,TTT>
    {
        Task<IEnumerable<T>> GetAll();
        Task<TT> GetById(Guid id);
        Task<bool> Add(TTT entity);
        Task<bool> Update(TTT entity);
        Task<bool> Delete(Guid id);
    }
}
