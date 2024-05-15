using BudgetApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Dtos.GoalUtils
{
    public class GoalResponse
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public decimal Budget { get; set; }
        public decimal Target { get; set; }
    }
}
