using BudgetApp.Data;
using BudgetApp.Repositories.CategoryRepository;
using BudgetApp.Repositories.ExpenseRepository;
using BudgetApp.Repositories.GoalRepository;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opitons =>
            {
                opitons.UseSqlServer(configuration.GetConnectionString("DefaultConn"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
        }
    }
}
