using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public Guid CategoryId { get; set; }
    }
}
