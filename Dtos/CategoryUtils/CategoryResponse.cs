namespace BudgetApp.Dtos.CategoryUtils
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
