using FilmPortal.Core.Entities;
using FilmPortal.Core.Interfaces;
using FilmPortal.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmPortal.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FilmPortalDbContext _context;

        public CategoryRepository(FilmPortalDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
               .Include(c => c.MovieCategories)
               .ThenInclude(mc => mc.Movie)
               .ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
