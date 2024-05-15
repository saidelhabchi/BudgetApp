
namespace BudgetApp.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Image {  get; set; } = string.Empty;

        public static implicit operator Category(Task<Category?> v)
        {
            throw new NotImplementedException();
        }
    }
}
