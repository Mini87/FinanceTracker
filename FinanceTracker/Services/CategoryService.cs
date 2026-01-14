using FinanceTracker.Data;
using FinanceTracker.DTOs;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var exists = await _context.Categories.AnyAsync(c => c.Name == dto.Name);

            if (exists) { throw new InvalidOperationException("Category already exists."); }

            var category = new Category
            {
                Name = dto.Name,
                Type = dto.Type,
                ParentCategoryId = dto.ParentCategoryId
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new CategoryDto { Name = dto.Name, Type = dto.Type, ParentCategoryId = dto.ParentCategoryId };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                 .Select(c => new CategoryDto
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Type = c.Type,
                     ParentCategoryId = c.ParentCategoryId
                 })
                 .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) return null;

            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.Type,
                ParentCategoryId = c.ParentCategoryId
            };
            
            
        }

        public async Task<bool> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) return false;
            
            c.Name = dto.Name;
            c.Type = dto.Type;
            c.ParentCategoryId  = dto.ParentCategoryId;

            _context.SaveChangesAsync();
            return true;
        }
    }
}
