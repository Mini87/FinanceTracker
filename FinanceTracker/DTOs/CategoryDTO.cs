namespace FinanceTracker.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }

}
