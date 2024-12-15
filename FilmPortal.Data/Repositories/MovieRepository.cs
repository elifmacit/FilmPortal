using FilmPortal.Core.Entities;
using FilmPortal.Core.Interfaces;
using FilmPortal.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmPortal.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly FilmPortalDbContext _context;

        public MovieRepository(FilmPortalDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
