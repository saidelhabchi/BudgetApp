using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Dtos.ExpenseUtils
{
    public class ExpenseRequest
    {
        Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Amount { get; set; }
    }
}
