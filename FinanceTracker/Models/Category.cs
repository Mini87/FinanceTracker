using System.Collections.ObjectModel;

namespace FinanceTracker.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        // "Income" or "Expense"
        public string Type { get; set; } = null!;

        // Optional: for subcategories
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        // Optional: if multi-user
        public string? UserId { get; set; }
    }
}
