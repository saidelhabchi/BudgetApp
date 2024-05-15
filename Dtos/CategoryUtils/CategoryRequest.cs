namespace BudgetApp.Dtos.CategoryUtils
{
    public class CategoryRequest
    {
        public required string Name { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
