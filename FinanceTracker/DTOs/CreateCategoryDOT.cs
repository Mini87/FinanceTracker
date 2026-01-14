namespace FinanceTracker.DTOs
{


    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }
}