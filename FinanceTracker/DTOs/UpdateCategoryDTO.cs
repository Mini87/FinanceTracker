namespace FinanceTracker.DTOs
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }

}
