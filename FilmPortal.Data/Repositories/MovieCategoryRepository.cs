using FilmPortal.Core.Entities;
using FilmPortal.Core.Interfaces;
using FilmPortal.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmPortal.Data.Repositories
{
    public class MovieCategoryRepository : IMovieCategoryRepository
    {
        private readonly FilmPortalDbContext _context;

        public MovieCategoryRepository(FilmPortalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieCategory>> GetAllAsync()
        {
            return await _context.MovieCategories
                .Include(mc => mc.Movie)
                .Include(mc => mc.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieCategory>> GetByMovieIdAsync(int movieId)
        {
            return await _context.MovieCategories
                .Where(mc => mc.MovieId == movieId)
                .Include(mc => mc.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.MovieCategories
                .Where(mc => mc.CategoryId == categoryId)
                .Include(mc => mc.Movie)
                .ToListAsync();
        }

        public async Task AddAsync(MovieCategory movieCategory)
        {
            await _context.MovieCategories.AddAsync(movieCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId, int categoryId)
        {
            var movieCategory = await _context.MovieCategories
                .FirstOrDefaultAsync(mc => mc.MovieId == movieId && mc.CategoryId == categoryId);

            if (movieCategory != null)
            {
                _context.MovieCategories.Remove(movieCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
