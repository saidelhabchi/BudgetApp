﻿namespace BudgetApp.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T?> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}
