using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Repositories.GoalRepository
{
    public class GoalRepository : IGoalRepository
    {
        private readonly DataContext _dataContext;

        public GoalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<bool> Add(Goal entity)
        {
            try
            {
                _dataContext.Goals.Add(entity);
                _dataContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            Goal toBeDeleted = _dataContext.Goals.FirstOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                _dataContext.Remove(toBeDeleted);
                _dataContext.SaveChanges() ;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public IEnumerable<Goal> GetAll()
        {
            return _dataContext.Goals.ToList();
        }

        public Task<Goal?> GetById(Guid id)
        {
            Goal? goal = _dataContext.Goals.FirstOrDefault(g => g.Id == id);
            return Task.FromResult(goal);
        }

        public Task<bool> Update(Goal entity)
        {
            Goal? goal = _dataContext.Goals.FirstOrDefault(g => g.Id == entity.Id);
            if(goal == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                goal.Title = entity.Title;
                goal.Description = entity.Description;
                goal.Target = entity.Target;
                goal.Budget = entity.Budget;
                goal.UpdatedAt = DateTime.Now;
                _dataContext.SaveChanges();
                return Task.FromResult(true);
            }
        }
    }
}
