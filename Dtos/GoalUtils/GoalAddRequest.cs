using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Dtos.GoalUtils
{
    public class GoalAddRequest
    {
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Budget { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Target { get; set; }
        public Guid CategoryId { get; set; }
    }
}
