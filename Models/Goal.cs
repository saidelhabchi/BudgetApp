using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid CategoryId { get; set;}
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Budget { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Target { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
