using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public Task<bool> Add(Category entity)
        {
            try
            {
                _context.Categories.AddAsync(entity);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            try
            {
                var toBeDeleted = _context.Categories.FirstOrDefault(c => c.Id == id);
                if (toBeDeleted != null)
                {
                    _context.Categories.Remove(toBeDeleted);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch (Exception e)
            {
                return Task.FromResult(false);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Task<Category> GetById(Guid id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.Id == id);
                if(category != null)
                {
                    return Task.FromResult(category);
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<bool> Update(Category entity)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == entity.Id);
            if (category != null)
            {
                category.Name = entity.Name;
                category.Image = entity.Image;
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
