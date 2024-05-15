using BudgetApp.Data;
using BudgetApp.Models;

namespace BudgetApp.Repositories.ExpenseRepository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Expense entity)
        {
            try
            {
                _context.Expenses.Add(entity);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch(Exception ex) 
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            var toBeDeleted = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (toBeDeleted != null)
            {
                _context.Expenses.Remove(toBeDeleted);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public Task<Expense?> GetById(Guid id)
        {
            var expense = _context.Expenses.FirstOrDefault(ex => ex.Id == id);
            return Task.FromResult(expense ?? null);
        }

        public Task<bool> Update(Expense entity)
        {
            var toBeUpdated = _context.Expenses.FirstOrDefault(e => e.Id == entity.Id);
            if (toBeUpdated != null)
            {
                toBeUpdated.Title = entity.Title;
                toBeUpdated.Description = entity.Description;
                toBeUpdated.Amount = entity.Amount;
                toBeUpdated.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
